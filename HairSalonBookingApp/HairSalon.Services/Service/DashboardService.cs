using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.DashboardModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using static HairSalon.Core.Base.BaseException;

namespace HairSalon.Services.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Calculate Appointment Statistic
        public async Task<IEnumerable<StatisticAppointmentModelView>> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName)
        {
            ValidatePeriodName(periodName);

            var (actualStartPeriod, actualEndPeriod) = GetActualPeriods(startPeriod, endPeriod);

            // Kiểm tra khoảng thời gian
            if (actualEndPeriod < actualStartPeriod)
            {
                throw new ErrorException("StartPeriod must be smaller than endPeriod."); // Nếu thời gian kết thúc nhỏ hơn thời gian bắt đầu, ném ra ngoại lệ
            }

            // Lấy danh sách appointment đã lọc
            var filteredAppointments = await GetFilteredAppointments(actualStartPeriod, actualEndPeriod);

            // Kiểm tra xem có appointment nào không
            if (!filteredAppointments.Any())
            {
                return Enumerable.Empty<StatisticAppointmentModelView>(); // Nếu không có appointment, trả về danh sách rỗng
            }

            // Nhóm dữ liệu theo khoảng thời gian được chỉ định
            return GroupAndCalculateStatistics(filteredAppointments, periodName);
        }

        private void ValidatePeriodName(string periodName)
        {
            if (periodName != "day" && periodName != "month" && periodName != "year")
            {
                throw new ErrorException("Invalid period name. Must be 'day', 'month', or 'year'.");
            }
        }

        private (DateTime actualStartPeriod, DateTime actualEndPeriod) GetActualPeriods(string? startPeriod, string? endPeriod)
        {
            DateTime actualStartPeriod = ParseDate(startPeriod, DateTime.MinValue);
            DateTime actualEndPeriod = ParseDate(endPeriod, DateTime.Now);

            // Nếu không có endPeriod, lấy ngày cuối cùng của startPeriod
            if (actualStartPeriod != DateTime.MinValue && actualEndPeriod == DateTime.MinValue)
            {
                actualEndPeriod = new DateTime(actualStartPeriod.Year, 12, 31);
            }

            return (actualStartPeriod, actualEndPeriod);
        }

        private DateTime ParseDate(string? dateStr, DateTime defaultDate)
        {
            if (string.IsNullOrWhiteSpace(dateStr)) return defaultDate;

            if (dateStr.Length == 4 && int.TryParse(dateStr, out int year))
            {
                return new DateTime(year, 1, 1); // Ngày đầu tiên của năm
            }
            else if (dateStr.Length == 7 && DateTime.TryParseExact(dateStr, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime month))
            {
                return new DateTime(month.Year, month.Month, 1); // Ngày đầu tiên của tháng
            }
            else if (DateTime.TryParse(dateStr, out DateTime date))
            {
                return date; // Sử dụng ngày đầy đủ
            }

            throw new ErrorException("Invalid date format."); // Ném ngoại lệ nếu không hợp lệ
        }

        private async Task<List<Appointment>> GetFilteredAppointments(DateTime startPeriod, DateTime endPeriod)
        {
            return await _unitOfWork.GetRepository<Appointment>().Entities.AsNoTracking()
                .Where(a => a.AppointmentDate >= startPeriod
                         && a.AppointmentDate <= endPeriod
                         && a.StatusForAppointment == "Completed")
                .ToListAsync();
        }

        private IEnumerable<StatisticAppointmentModelView> GroupAndCalculateStatistics(List<Appointment> appointments, string periodName)
        {
            return appointments.GroupBy(o => periodName switch
            {
                "day" => o.AppointmentDate.Date, // Nhóm theo ngày
                "month" => new DateTime(o.AppointmentDate.Year, o.AppointmentDate.Month, 1), // Nhóm theo tháng
                "year" => new DateTime(o.AppointmentDate.Year, 1, 1), // Nhóm theo năm
                _ => throw new ErrorException("Invalid period name")
            })
            .Select(g => new StatisticAppointmentModelView
            {
                PeriodTime = g.Key switch
                {
                    DateTime dt when periodName == "day" => dt.ToString("yyyy-MM-dd"), // Định dạng PeriodTime theo ngày
                    DateTime dt when periodName == "month" => dt.ToString("yyyy-MM"), // Định dạng PeriodTime theo tháng
                    DateTime dt when periodName == "year" => dt.ToString("yyyy"), // Định dạng PeriodTime theo năm
                    _ => throw new ErrorException("Invalid period name") // Trường hợp này không nên xảy ra
                },
                TotalAmount = g.Sum(a => a.TotalAmount),
                TotalFeedback = g.Count(a => a.Feedback != null),
                TotalAppointment = g.Count()
            })
            .ToList();
        }
        #endregion

        public async Task<IEnumerable<TopUserModelView>> GetTopUsersByTotalAmount(int? top)
        {
            // Lấy danh sách người dùng có tổng TotalAmount từ các Appointment đã hoàn thành
            var query = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => a.StatusForAppointment == "Completed")
                .GroupBy(a => a.UserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    TotalAmount = g.Sum(a => a.TotalAmount),
                    TotalAppointment = g.Count()
                })
                .OrderByDescending(x => x.TotalAmount)
                .Take(top ?? 5) // Lấy top người dùng, mặc định là 5
                .ToListAsync();

            // Lấy danh sách UserId từ kết quả truy vấn
            var userIds = query.Select(x => x.UserId).ToList();

            // Truy vấn thông tin người dùng
            var users = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();

            // Thực hiện ánh xạ trên client side
            var result = users
                .Select(u => new TopUserModelView
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Firstname = u.UserInfo.Firstname,
                    Lastname = u.UserInfo.Lastname,
                    TotalAmount = query.Where(x => x.UserId == u.Id).Select(x => x.TotalAmount).FirstOrDefault(),
                    TotalAppointment = query.Where(x => x.UserId == u.Id).Select(x => x.TotalAppointment).FirstOrDefault()
                })
                .OrderByDescending(x => x.TotalAmount)
                .ToList();

            return result;
        }

    }
}
