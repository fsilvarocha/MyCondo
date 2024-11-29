using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.Application.Services.CondominioService.Interface;

public interface ICondominiosService : IBaseService<CondominiosPesquisaRequest,
                                                    CondominiosInserirRequest,
                                                    CondominiosAtualizarRequest,
                                                    CondominiosExcluirRequest,
                                                    CondominiosResponse>
{
}
