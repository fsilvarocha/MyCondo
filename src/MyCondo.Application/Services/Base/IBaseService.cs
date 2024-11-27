namespace MyCondo.Application.Services.Base;

public interface IBaseService<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse>
    where TPesquisa : class
    where TInserir : class
    where TAtualizar : class
    where TDeletar : class
    where TResponse : class
{
    Task<TResponse?> GetByIdTenanteAsync(TPesquisa entity);
    Task<IEnumerable<TResponse>> GetAllAsync();
    Task<TResponse> AddAsync(TInserir entity);
    Task UpdateAsync(int id, Guid tenante, TAtualizar entity);
    Task DeleteAsync(TDeletar entity);
}
