using Microsoft.EntityFrameworkCore;
using MyCondo.Domain.Interface.Base;
using MyCondo.Infra.Data;

namespace MyCondo.Infra.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly MyCondoContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(MyCondoContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    public async Task<T?> GetByIdTenanteAsync(T entity)
    {
        string tenante = entity.GetType().GetProperty("Tenante")?.GetValue(entity)?.ToString();
        int id = (int)entity.GetType().GetProperty("Id")?.GetValue(entity);

        if (string.IsNullOrEmpty(tenante))
            return null;

        T retorno = await _dbSet.FirstOrDefaultAsync(x =>
            EF.Property<string>(x, "Tenante").Equals(tenante, StringComparison.CurrentCultureIgnoreCase) && EF.Property<int>(x, "Id") == id);

        return retorno;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
