using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.DashboardModelViews;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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

        public async Task<IEnumerable<StatisticAppointmentModelView>> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName)
        {
            // Kiểm tra giá trị của periodName
            if (periodName != "day" && periodName != "month" && periodName != "year")
            {
                throw new ErrorException("Invalid period name. Must be 'day', 'month', or 'year'.");
            }

            // Khai báo biến để lưu trữ thời gian bắt đầu và kết thúc
            DateTime actualStartPeriod;
            DateTime actualEndPeriod;

            // Xử lý startPeriod
            if (string.IsNullOrWhiteSpace(startPeriod) || !DateTime.TryParse(startPeriod, out actualStartPeriod))
            {
                // Nếu startPeriod chỉ chứa năm, chuyển đổi thành DateTime
                if (int.TryParse(startPeriod, out int startYear))
                {
                    actualStartPeriod = new DateTime(startYear, 1, 1); // Gán ngày 1 tháng 1 của năm đó
                }
                else
                {
                    actualStartPeriod = DateTime.MinValue; // Nếu không hợp lệ, mặc định là ngày nhỏ nhất
                }
            }
            else
            {
                actualStartPeriod = DateTime.Parse(startPeriod); // Nếu hợp lệ, chuyển đổi sang DateTime
            }

            // Xử lý endPeriod
            if (string.IsNullOrWhiteSpace(endPeriod) || !DateTime.TryParse(endPeriod, out actualEndPeriod))
            {
                // Nếu endPeriod chỉ chứa năm, chuyển đổi thành DateTime
                if (int.TryParse(endPeriod, out int endYear))
                {
                    actualEndPeriod = new DateTime(endYear, 12, 31); // Gán ngày cuối cùng của năm đó
                }
                else
                {
                    actualEndPeriod = DateTime.Now; // Nếu không hợp lệ, mặc định là ngày hiện tại
                }
            }
            else
            {
                actualEndPeriod = DateTime.Parse(endPeriod); // Nếu hợp lệ, chuyển đổi sang DateTime
            }

            // Kiểm tra khoảng thời gian
            if (actualEndPeriod < actualStartPeriod)
            {
                throw new ErrorException("StartPeriod must be smaller than endPeriod."); // Nếu thời gian kết thúc nhỏ hơn thời gian bắt đầu, ném ra ngoại lệ
            }

            // Lấy danh sách cuộc hẹn đã lọc
            var filteredAppointments = await _unitOfWork.GetRepository<Appointment>().Entities.AsNoTracking()
                        .Where(a => a.AppointmentDate >= actualStartPeriod
                                 && a.AppointmentDate <= actualEndPeriod
                                 && a.StatusForAppointment == "Completed")
                        .ToListAsync();

            // Kiểm tra xem có cuộc hẹn nào không
            if (!filteredAppointments.Any())
            {
                return Enumerable.Empty<StatisticAppointmentModelView>(); // Nếu không có cuộc hẹn, trả về danh sách rỗng
            }

            // Nhóm dữ liệu theo khoảng thời gian được chỉ định
            var statistics = filteredAppointments.GroupBy(o => periodName switch
            {
                "day" => o.AppointmentDate.Date, // Nhóm theo ngày
                "month" => new DateTime(o.AppointmentDate.Year, o.AppointmentDate.Month, 1), // Nhóm theo tháng
                "year" => new DateTime(o.AppointmentDate.Year, 1, 1), // Nhóm theo năm
                _ => throw new ErrorException("Invalid period name") // Trường hợp này không nên xảy ra vì đã được kiểm tra trước đó
            })
            // Tính toán tổng cho mỗi nhóm
            .Select(g => new StatisticAppointmentModelView
            {
                // Định dạng periodTime thành chuỗi "yyyy-MM-dd"
                PeriodTime = g.Key.ToString("yyyy-MM-dd"),
                TotalAmount = g.Sum(a => a.TotalAmount), // Tổng số tiền
                TotalFeedback = g.Count(a => a.Feedback != null), // Số lượng phản hồi
                TotalAppointment = g.Count() // Tổng số cuộc hẹn
            })
            .ToList();

            // Trả về danh sách thống kê
            return statistics;
        }


    }
}
