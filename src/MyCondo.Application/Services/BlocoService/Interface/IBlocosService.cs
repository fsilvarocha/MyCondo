using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

namespace MyCondo.Application.Services.BlocoService.Interface;

public interface IBlocosService : IBaseService<BlocosPesquisaRequest,
                                               BlocosInserirRequest,
                                               BlocosAtualizarRequest,
                                               BlocosExcluirRequest,
                                               BlocosResponse>
{
}
