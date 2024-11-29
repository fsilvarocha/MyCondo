using AutoMapper;
using MyCondo.Application.Services.Base;
using MyCondo.Application.Services.BlocoService.Interface;
using MyCondo.Domain.Entities.Bloco;
using MyCondo.Domain.Interface.Bloco;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

namespace MyCondo.Application.Services.BlocoService;

public class BlocosService : BaseService<Blocos,
                                         BlocosPesquisaRequest,
                                         BlocosInserirRequest,
                                         BlocosAtualizarRequest,
                                         BlocosExcluirRequest,
                                         BlocosResponse>,IBlocosService
{
    private readonly IBlocosRepository _blocosRepository;
    private readonly IMapper _mapper;

    public BlocosService(IBlocosRepository blocosRepository, IMapper mapper) : base(mapper,blocosRepository)
    {
        _blocosRepository = blocosRepository;
        _mapper = mapper;
    }
}
