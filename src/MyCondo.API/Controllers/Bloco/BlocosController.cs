using MyCondo.API.Controllers.Base;
using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

namespace MyCondo.API.Controllers.Bloco;


public class BlocosController : BaseController<BlocosPesquisaRequest,
                                               BlocosInserirRequest,
                                               BlocosAtualizarRequest,
                                               BlocosExcluirRequest,
                                               BlocosResponse>
{
    public BlocosController(IBaseService<BlocosPesquisaRequest,
                                               BlocosInserirRequest,
                                               BlocosAtualizarRequest,
                                               BlocosExcluirRequest,
                                               BlocosResponse> service,
                            ILogger<BaseController<BlocosPesquisaRequest,
                                               BlocosInserirRequest,
                                               BlocosAtualizarRequest,
                                               BlocosExcluirRequest,
                                               BlocosResponse>> logger) : base(service, logger)
    {
    }
}
