using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.Application.Services.CondominioService.Interface;

public interface ICondominiosService
{
    Task<IEnumerable<CondominiosResponse>> GetAllAsync();
    Task<CondominiosResponse> AddAsync(CondominiosInserirRequest entity);
    Task<CondominiosResponse> GetByIdTenanteAsync(CondominiosPesquisaRequest entity);
}
