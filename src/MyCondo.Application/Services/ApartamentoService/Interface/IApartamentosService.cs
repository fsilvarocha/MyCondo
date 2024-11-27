using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

namespace MyCondo.Application.Services.ApartamentoService.Interface;

public interface IApartamentosService : IBaseService<ApartamentosPesquisaRequest,
                                                 ApartamentosInserirRequest,
                                                 ApartamentosAtualizarRequest,
                                                 ApartamentosExcluirRequest,
                                                 ApartamentosResponse>
{

}
