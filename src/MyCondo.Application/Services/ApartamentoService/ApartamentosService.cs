using AutoMapper;
using MyCondo.Application.Services.ApartamentoService.Interface;
using MyCondo.Application.Services.Base;
using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Interface.Apartamento;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

namespace MyCondo.Application.Services.ApartamentoService;

public class ApartamentosService : BaseService<Apartamentos,
                                               ApartamentosPesquisaRequest,
                                               ApartamentosInserirRequest,
                                               ApartamentosAtualizarRequest,
                                               ApartamentosExcluirRequest,
                                               ApartamentosResponse>, IApartamentosService
{
    private readonly IApartamentosRepository _apartamentoRepository;
    private readonly IMapper _mapper;

    public ApartamentosService(IApartamentosRepository repository, IMapper mapper) : base(mapper, repository)
    {
        _apartamentoRepository = repository;
        _mapper = mapper;
    }
}
