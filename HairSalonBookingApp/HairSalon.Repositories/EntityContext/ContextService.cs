using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.EntityContext;

public class ContextService<T> where T : class
{
    private readonly DatabaseContext _databaseContext;

    public ContextService(DatabaseContext databaseContext)
        => _databaseContext = databaseContext;


    /**
     * lấy ra 1 đối tượng với kiễu dữ liệu <T
     */
    public async Task<T?> GetObjectById(Guid id)
    {
        return _databaseContext.Set<T>().Find(id);
    }

    /**
     * them 1 dối tượng vao db
     */
    public async Task AddObjAsync(T obj)
    {
        await _databaseContext.Set<T>().AddAsync(obj);
        await _databaseContext.SaveChangesAsync();
    }


    /**
     * lay ta ca ca obj trong db theo tung loai du lieu(obj)
     */
    public async Task<IList<T>> GetAllObjAsync()
        => await _databaseContext.Set<T>().ToListAsync();


    /**
     * update obj
     */
    public async Task UpdateObjAsync(T obj)
    {
        _databaseContext.Set<T>().Update(obj);
        await _databaseContext.SaveChangesAsync();
    }

    /**
     * xóa obj
     */
    
    public async Task DeleteObjAsync(Guid id)
    {
        var obj = await _databaseContext.Set<T>().FindAsync(id);
        if (obj == null)
        {
            return;
        }

        _databaseContext.Set<T>().Remove(obj);
        await _databaseContext.SaveChangesAsync();
    }
}