using AutoMapper;
using MyCondo.Application.Services.Base;
using MyCondo.Application.Services.MoradorService.Interface;
using MyCondo.Domain.Entities.Morador;
using MyCondo.Domain.Interface.Morador;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;

namespace MyCondo.Application.Services.MoradorService;

public class MoradoresService : BaseService<Moradores, MoradoresPesquisaRequest,
                                                       MoradoresInserirRequest,
                                                       MoradoresAtualizarRequest,
                                                       MoradoresExcluirRequest,
                                                       MoradoresResponse>, IMoradoresService
{
    private readonly IMoradoresRepository _moradorRepository;
    private readonly IMapper _mapper;

    public MoradoresService(IMoradoresRepository moradorRepository, IMapper mapper) : base(mapper, moradorRepository)
    {
        _moradorRepository = moradorRepository;
        _mapper = mapper;
    }
}

