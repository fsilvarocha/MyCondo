using MyCondo.API.Controllers.Base;
using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.API.Controllers.Condominio
{

    public class CondominiosController : BaseController<CondominiosPesquisaRequest,
                                                         CondominiosInserirRequest,
                                                         CondominiosAtualizarRequest,
                                                         CondominiosExcluirRequest,
                                                         CondominiosResponse>
    {
        public CondominiosController(IBaseService<CondominiosPesquisaRequest,
                                                  CondominiosInserirRequest,
                                                  CondominiosAtualizarRequest,
                                                  CondominiosExcluirRequest,
                                                  CondominiosResponse> service,
                                     ILogger<BaseController<CondominiosPesquisaRequest,
                                                            CondominiosInserirRequest,
                                                            CondominiosAtualizarRequest,
                                                            CondominiosExcluirRequest,
                                                            CondominiosResponse>> logger) : base(service, logger)
        {

        }
    }
}
