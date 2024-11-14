using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.DashboardModelViews;
using HairSalon.ModelViews.ServiceModelViews;
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
        public async Task<BasePaginatedList<StatisticAppointmentModelView>> GetAppointmentStatistic
            (string? startPeriod, string? endPeriod, string periodName, int pageNumber, int pageSize)
        {
            ValidatePeriodName(periodName);

            var (actualStartPeriod, actualEndPeriod) = GetActualPeriods(startPeriod, endPeriod);

            // Check if the period range is valid
            if (actualEndPeriod < actualStartPeriod)
            {
                throw new ErrorException("StartPeriod must be smaller than endPeriod."); // If the end date is earlier than the start date, throw an exception
            }

            // Get the list of filtered appointments
            var filteredAppointments = await GetFilteredAppointments(actualStartPeriod, actualEndPeriod);

            // Check if there are any appointments
            // Check if there are any appointments
            if (!filteredAppointments.Any())
            {
                // Return an empty paginated list with zero items
                return new BasePaginatedList<StatisticAppointmentModelView>(new List<StatisticAppointmentModelView>(), 0, pageNumber, pageSize);
            }

            // Group and calculate statistics based on the specified period
            var statistics = GroupAndCalculateStatistics(filteredAppointments, periodName);

            // Calculate total count of statistics for pagination
            int totalCount = statistics.Count();

            // Ensure pageNumber is within the valid range
            pageNumber = Math.Clamp(pageNumber, 1, (int)Math.Ceiling(totalCount / (double)pageSize));

            // Apply pagination to the statistics
            var paginatedStatistics = statistics
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Return the paginated statistics along with pagination details
            return new BasePaginatedList<StatisticAppointmentModelView>(paginatedStatistics, totalCount, pageNumber, pageSize);
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
            // Parse the start and end periods
            DateTime actualStartPeriod = ParseDate(startPeriod, DateTime.MinValue, isStartPeriod: true);
            DateTime actualEndPeriod = ParseDate(endPeriod, DateTime.MinValue, isStartPeriod: false);

            // Set actualEndPeriod to "now" if it wasn't explicitly specified
            if (actualEndPeriod == DateTime.MinValue)
            {
                actualEndPeriod = DateTime.Now;
            }

            return (actualStartPeriod, actualEndPeriod);
        }

        private DateTime ParseDate(string? dateStr, DateTime defaultDate, bool isStartPeriod)
        {
            if (string.IsNullOrWhiteSpace(dateStr)) return defaultDate;

            if (dateStr.Length == 4 && int.TryParse(dateStr, out int year))
            {
                return isStartPeriod
                    ? new DateTime(year, 1, 1) // Start of the given year
                    : new DateTime(year, 12, 31, 23, 59, 59); // End of the given year
            }
            else if (dateStr.Length == 7 && DateTime.TryParseExact(dateStr, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime month))
            {
                return isStartPeriod
                    ? new DateTime(month.Year, month.Month, 1) // Start of the given month
                    : new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month), 23, 59, 59); // End of the given month
            }
            else if (DateTime.TryParse(dateStr, out DateTime date))
            {
                return isStartPeriod ? date.Date : date.Date.AddDays(1).AddTicks(-1); // Use the full date and cover the entire day for end periods
            }

            throw new ErrorException("Invalid date format."); // Throw an exception for invalid format
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
                "day" => o.AppointmentDate.Date, // Group by day
                "month" => new DateTime(o.AppointmentDate.Year, o.AppointmentDate.Month, 1), // Group by month
                "year" => new DateTime(o.AppointmentDate.Year, 1, 1), // Group by year
                _ => throw new ErrorException("Invalid period name")
            })
            .Select(g => new StatisticAppointmentModelView
            {
                PeriodTime = g.Key switch
                {
                    DateTime dt when periodName == "day" => dt.ToString("yyyy-MM-dd"), // Format PeriodTime as a day
                    DateTime dt when periodName == "month" => dt.ToString("yyyy-MM"), // Format PeriodTime as a month
                    DateTime dt when periodName == "year" => dt.ToString("yyyy"), // Format PeriodTime as a year
                    _ => throw new ErrorException("Invalid period name")
                },
                TotalAmount = g.Sum(a => a.TotalAmount), // Sum the total amount
                TotalFeedback = g.Count(a => a.Feedback != null), // Count the number of appointments with feedback
                TotalAppointment = g.Count() // Count the total number of appointments
            })
            .ToList();
        }
        #endregion

        public async Task<BasePaginatedList<TopUserModelView>> GetTopUsersByTotalAmount(int? top, int pageNumber, int pageSize)
        {
            // Get a list of users with the total TotalAmount from completed Appointments
            var query = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => a.StatusForAppointment == "Completed")
                .GroupBy(a => a.UserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    TotalAmount = g.Sum(a => a.TotalAmount), // Calculate the sum of TotalAmount
                    TotalFeedback = g.Count(a => a.Feedback != null),
                    TotalAppointment = g.Count() // Count the number of completed Appointments
                })
                .OrderByDescending(x => x.TotalAmount)
                .ToListAsync();

            // Get the top users, default to 5
            var topUsersQuery = query.Take(top ?? 5);

            // Paginate the results
            var totalCount = topUsersQuery.Count();
            var paginatedUsers = topUsersQuery.Skip((pageNumber - 1) * pageSize)
                                               .Take(pageSize)
                                               .ToList();

            // Get the list of UserIds from the query results
            var userIds = paginatedUsers.Select(x => x.UserId).ToList();

            // Fetch user information from the ApplicationUsers repository
            var users = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();

            // Perform client-side mapping
            var result = users
                .Select(u => new TopUserModelView
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Firstname = u.UserInfo.Firstname,
                    Lastname = u.UserInfo.Lastname,
                    TotalAmount = paginatedUsers.FirstOrDefault(x => x.UserId == u.Id)?.TotalAmount ?? 0,
                    TotalFeedback = paginatedUsers.FirstOrDefault(x => x.UserId == u.Id)?.TotalFeedback ?? 0,
                    TotalAppointment = paginatedUsers.FirstOrDefault(x => x.UserId == u.Id)?.TotalAppointment ?? 0
                })
                .OrderByDescending(x => x.TotalAmount)
                .ToList();

            // Return the paginated list
            return new BasePaginatedList<TopUserModelView>(result, totalCount, pageNumber, pageSize);
        }

        public async Task<BasePaginatedList<StatisticalComboModelView>> GetStatisticalCombosAsync(int pageNumber, int pageSize, int? month, int? year)
        {
            // Return an empty list if month is provided without year
            if (month.HasValue && !year.HasValue)
            {
                return new BasePaginatedList<StatisticalComboModelView>(new List<StatisticalComboModelView>(), 0, pageNumber, pageSize);
            }

            // Filter appointments based on year and month, including only valid (non-deleted) appointments
            IQueryable<Appointment> appointmentQuery = _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => !a.DeletedTime.HasValue);

            // Apply year filter if provided
            if (year.HasValue)
            {
                appointmentQuery = appointmentQuery.Where(a => a.AppointmentDate.Year == year.Value);
            }

            // Apply month filter only if both month and year are provided
            if (month.HasValue && year.HasValue)
            {
                appointmentQuery = appointmentQuery.Where(a => a.AppointmentDate.Month == month.Value);
            }

            // Query ComboAppointments with the filtered Appointment IDs
            var comboUsageQuery = _unitOfWork.GetRepository<ComboAppointment>().Entities
                .Where(ca => appointmentQuery.Select(a => a.Id).Contains(ca.AppointmentId))
                .GroupBy(ca => ca.Combo.Name) // Group by Combo Name
                .Select(group => new StatisticalComboModelView
                {
                    Name = group.Key,
                    TotalCombo = group.Count() // Count each Combo's usage across appointments
                })
                .OrderByDescending(c => c.TotalCombo); // Sort by usage count in descending order

            // Get total count before pagination
            int totalCount = await comboUsageQuery.CountAsync();

            // Retrieve paginated results
            var paginatedComboUsage = await comboUsageQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated list with total count
            return new BasePaginatedList<StatisticalComboModelView>(paginatedComboUsage, totalCount, pageNumber, pageSize);
        }



        // Get number of each service per month
        public async Task<BasePaginatedList<StatisticalServiceModelView>> MonthlyServiceStatistics(int pageNumber, int pageSize, int? month, int? year)
        {
            // Check if only month is provided without year
            if (month.HasValue && !year.HasValue)
            {
                return new BasePaginatedList<StatisticalServiceModelView>(new List<StatisticalServiceModelView>(), 0, pageNumber, pageSize);
            }

            // Filter ServiceAppointments based on year and month, including only valid (non-deleted) appointments
            IQueryable<Appointment> serviceUsageQuery = _unitOfWork.GetRepository<Appointment>().Entities
                .Where(sa => !sa.DeletedTime.HasValue && !sa.DeletedTime.HasValue);

            // Apply year filter if provided
            if (year.HasValue)
            {
                serviceUsageQuery = serviceUsageQuery.Where(sa => sa.AppointmentDate.Year == year.Value);
            }

            // Apply month filter only if both month and year are provided
            if (month.HasValue && year.HasValue)
            {
                serviceUsageQuery = serviceUsageQuery.Where(sa => sa.AppointmentDate.Month == month.Value);
            }

            // Query ComboAppointments with the filtered Appointment IDs
            var serviceUsageQuerys = _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(ca => serviceUsageQuery.Select(a => a.Id).Contains(ca.AppointmentId))
                .GroupBy(ca => ca.Service.Name) // Group by Combo Name
                .Select(group => new StatisticalServiceModelView
                {
                    ServiceName = group.Key,
                    UsageCount = group.Count() // Count each Combo's usage across appointments
                })
                .OrderByDescending(c => c.UsageCount); // Sort by usage count in descending order

            // Get total count before pagination
            int totalCount = await serviceUsageQuerys.CountAsync();

            // Retrieve paginated results
            var paginatedComboUsage = await serviceUsageQuerys
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated list with total count
            return new BasePaginatedList<StatisticalServiceModelView>(paginatedComboUsage, totalCount, pageNumber, pageSize);
        }

    }
}
