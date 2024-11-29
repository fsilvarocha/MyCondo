using MyCondo.Application.Services.Base;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;

namespace MyCondo.Application.Services.MoradorService.Interface;

public interface IMoradoresService : IBaseService<MoradoresPesquisaRequest,
                                                  MoradoresInserirRequest,
                                                  MoradoresAtualizarRequest,
                                                  MoradoresExcluirRequest,
                                                  MoradoresResponse>
{
}
