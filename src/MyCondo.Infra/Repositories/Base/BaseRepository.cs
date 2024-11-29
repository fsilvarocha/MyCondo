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
        // Obtém os valores de "Tenante" e "Id" dinamicamente
        var tenanteProperty = entity.GetType().GetProperty("Tenante");
        var idProperty = entity.GetType().GetProperty("Id");

        if (tenanteProperty == null || idProperty == null)
            throw new InvalidOperationException("A entidade fornecida não possui as propriedades esperadas: 'Tenante' ou 'Id'.");

        // Obtém os valores de Tenante e Id
        string tenante = tenanteProperty.GetValue(entity)?.ToString();
        int id = (int)idProperty.GetValue(entity);

        // Verifica valores nulos ou inválidos
        if (string.IsNullOrEmpty(tenante))
            return null;

        try
        {
            var retorno = await _dbSet.FirstOrDefaultAsync(x =>
                EF.Property<string>(x, "Tenante").ToLower() == tenante.ToString().ToLower() &&
                EF.Property<int>(x, "Id") == id);

            return retorno;
        }
        catch (Exception ex)
        {
            // Logar o erro, se necessário
            throw new InvalidOperationException("Erro ao executar a consulta no banco de dados.", ex);
        }
    }

    public async Task UpdateAsync(T entity)
    {
        var property = entity.GetType().GetProperty("DataAtualizado");

        if (property != null && property.CanWrite)
            property.SetValue(entity, DateTime.Now);

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

}
