using MyCondo.API.Controllers.Base;
using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

namespace MyCondo.API.Controllers.Apartamento
{
    public class ApartamentosController : BaseController<ApartamentosPesquisaRequest,
                                                         ApartamentosInserirRequest,
                                                         ApartamentosAtualizarRequest,
                                                         ApartamentosExcluirRequest,
                                                         ApartamentosResponse>
    {
        public ApartamentosController(IBaseService<ApartamentosPesquisaRequest,
                                                         ApartamentosInserirRequest,
                                                         ApartamentosAtualizarRequest,
                                                         ApartamentosExcluirRequest,
                                                         ApartamentosResponse> service,
                                      ILogger<BaseController<ApartamentosPesquisaRequest,
                                                         ApartamentosInserirRequest,
                                                         ApartamentosAtualizarRequest,
                                                         ApartamentosExcluirRequest,
                                                         ApartamentosResponse>> logger) : base(service, logger)
        {

        }
    }
}
