using AutoMapper;
using MyCondo.Application.Services.ApartamentoService.Interface;
using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Interface.Apartamento;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

namespace MyCondo.Application.Services.ApartamentoService;

public class ApartamentosService : IApartamentosService
{
    private readonly IApartamentosRepository _apartamentoRepository;
    private readonly IMapper _mapper;

    public ApartamentosService(IApartamentosRepository repository, IMapper mapper)
    {
        _apartamentoRepository = repository;
        _mapper = mapper;
    }

    public async Task<ApartamentosResponse> AddAsync(ApartamentosInserirRequest entity)
    {
        Apartamentos apartamentos = _mapper.Map<Apartamentos>(entity);
        await _apartamentoRepository.AddAsync(apartamentos);
        ApartamentosResponse resonse = _mapper.Map<ApartamentosResponse>(apartamentos);
        return resonse;
    }

    public async Task DeleteAsync(ApartamentosExcluirRequest entity)
    {
        ApartamentosPesquisaRequest apartamentosPesquisa = ParsePesquisa(entity.Id, entity.Tenante);
        Apartamentos apartamentos = _mapper.Map<Apartamentos>(apartamentosPesquisa);

        Apartamentos existeApartamento = await _apartamentoRepository.GetByIdTenanteAsync(apartamentos);
        if (existeApartamento != null)
            return;

        await _apartamentoRepository.DeleteAsync(existeApartamento);
    }

    public async Task<IEnumerable<ApartamentosResponse>> GetAllAsync()
    {
        IEnumerable<Apartamentos> apartamentos = await _apartamentoRepository.GetAllAsync();
        IEnumerable<ApartamentosResponse> retorno = _mapper.Map<IEnumerable<ApartamentosResponse>>(apartamentos);
        return retorno;
    }

    public async Task<ApartamentosResponse?> GetByIdTenanteAsync(ApartamentosPesquisaRequest entity)
    {
        Apartamentos apartamentos = _mapper.Map<Apartamentos>(entity);
        Apartamentos existeApartamento = await _apartamentoRepository.GetByIdTenanteAsync(apartamentos);
        ApartamentosResponse retorno = _mapper.Map<ApartamentosResponse>(existeApartamento);
        return retorno;
    }

    public async Task UpdateAsync(int id, Guid tenante, ApartamentosAtualizarRequest entity)
    {
        ApartamentosPesquisaRequest apartamentosPesquisa = ParsePesquisa(id, tenante);
        Apartamentos apartamentos = _mapper.Map<Apartamentos>(apartamentosPesquisa);

        Apartamentos existeApartamento = await _apartamentoRepository.GetByIdTenanteAsync(apartamentos);

        if (existeApartamento == null)
            return;

        existeApartamento.SetTipoApartamento(entity.TipoApartamento);
        existeApartamento.SetAndar(entity.Andar);
        existeApartamento.SetNumero(entity.Numero);

        await _apartamentoRepository.UpdateAsync(existeApartamento);
    }

    private ApartamentosPesquisaRequest ParsePesquisa(int id, Guid tenante)
    {
        return new()
        {
            Id = id,
            Tenante = tenante,
        };
    }

}
