using AutoMapper;
using MyCondo.Application.Services.CondominioService.Interface;
using MyCondo.Domain.Entities.Condominio;
using MyCondo.Domain.Interface.Condominio;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.Application.Services.CondominioService;

public class CondominiosService : ICondominiosService
{
    private readonly ICondominiosRepository _condominiosRepository;
    private readonly IMapper _mapper;

    public CondominiosService(ICondominiosRepository condominiosRepository, IMapper mapper)
    {
        _condominiosRepository = condominiosRepository;
        _mapper = mapper;
    }

    public async Task<CondominiosResponse> AddAsync(CondominiosInserirRequest entity)
    {
        Condominios condominios = _mapper.Map<Condominios>(entity);
        await _condominiosRepository.AddAsync(condominios);
        CondominiosResponse response = _mapper.Map<CondominiosResponse>(condominios);
        return response;
    }

    public async Task<IEnumerable<CondominiosResponse>> GetAllAsync()
    {
        IEnumerable<Condominios> listaCondominio = await _condominiosRepository.GetAllAsync();
        IEnumerable<CondominiosResponse> retorno = _mapper.Map<IEnumerable<CondominiosResponse>>(listaCondominio);
        return retorno;
    }

    public async Task<CondominiosResponse> GetByIdTenanteAsync(CondominiosPesquisaRequest entity)
    {
        Condominios comando = _mapper.Map<Condominios>(entity);
        Condominios condominio = await _condominiosRepository.GetByIdTenanteAsync(comando);
        CondominiosResponse retorno = _mapper.Map<CondominiosResponse>(condominio);
        return retorno;
    }
}
