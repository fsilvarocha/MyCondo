using MyCondo.API.Controllers.Base;
using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;

namespace MyCondo.API.Controllers.Morador;


public class MoradoresController : BaseController<MoradoresPesquisaRequest,
                                                  MoradoresInserirRequest,
                                                  MoradoresAtualizarRequest,
                                                  MoradoresExcluirRequest,
                                                  MoradoresResponse>
{
    public MoradoresController(
        IBaseService<MoradoresPesquisaRequest,
                     MoradoresInserirRequest,
                     MoradoresAtualizarRequest,
                     MoradoresExcluirRequest,
                     MoradoresResponse> service,
        ILogger<BaseController<MoradoresPesquisaRequest,
                               MoradoresInserirRequest,
                               MoradoresAtualizarRequest,
                               MoradoresExcluirRequest,
                               MoradoresResponse>> logger)
        : base(service, logger)
    {
    }
}
