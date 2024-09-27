using HairSalon.Contract.Repositories.Entity;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW;

public class ServiceAppointmentRepository : GenericRepository<ServiceAppointment>
{
    // Khai báo biến để lưu trữ ngữ cảnh cơ sở dữ liệu  
    protected readonly DatabaseContext _context;

    // Khai báo biến để lưu trữ tập hợp TutorSubject trong cơ sở dữ liệu  
    protected readonly DbSet<ServiceAppointment>? _dbSet;
    
    public ServiceAppointmentRepository(DatabaseContext dbContext) : base(dbContext)
    {
        // Gán ngữ cảnh cơ sở dữ liệu cho biến _context  
        _context = dbContext;

        // Thiết lập _dbSet để làm việc với các thực thể TutorSubject  
        _dbSet = _context.Set<ServiceAppointment>();
    }
}