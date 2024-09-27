using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        // Khai báo biến để lưu trữ ngữ cảnh cơ sở dữ liệu  
        protected readonly DatabaseContext _context;

        // Khai báo biến để lưu trữ tập hợp TutorSubject trong cơ sở dữ liệu  
        protected readonly DbSet<Appointment> _dbSet;

        // Constructor nhận vào DatabaseContext và truyền cho lớp cơ sở thông qua base  
        public AppointmentRepository(DatabaseContext dbContext) : base(dbContext)
        {
            // Gán ngữ cảnh cơ sở dữ liệu cho biến _context  
            _context = dbContext;

            // Thiết lập _dbSet để làm việc với các thực thể TutorSubject  
            _dbSet = _context.Set<Appointment>();
        }
    }
}
