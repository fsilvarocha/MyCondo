using AutoMapper;
using MyCondo.Application.Services.BlocoService.Interface;
using MyCondo.Domain.Entities.Bloco;
using MyCondo.Domain.Interface.Bloco;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

namespace MyCondo.Application.Services.BlocoService;

public class BlocosService : IBlocosService
{
    private readonly IBlocosRepository _blocosRepository;
    private readonly IMapper _mapper;

    public BlocosService(IBlocosRepository blocosRepository, IMapper mapper)
    {
        _blocosRepository = blocosRepository;
        _mapper = mapper;
    }

    public async Task<BlocosResponse> AddAsync(BlocosInserirRequest entity)
    {
        Blocos blocos = _mapper.Map<Blocos>(entity);
        await _blocosRepository.AddAsync(blocos);
        BlocosResponse response = _mapper.Map<BlocosResponse>(blocos);
        return response;
    }

    public async Task DeleteAsync(BlocosExcluirRequest entity)
    {
        BlocosPesquisaRequest blocosPesquisa = ParsePesquisa(entity.Id, entity.Tenante);
        Blocos pesquisa = _mapper.Map<Blocos>(blocosPesquisa);

        Blocos existeBloco = await _blocosRepository.GetByIdTenanteAsync(pesquisa);

        if (existeBloco == null)
            return;

        await _blocosRepository.DeleteAsync(existeBloco);
    }

    public async Task<IEnumerable<BlocosResponse>> GetAllAsync()
    {
        IEnumerable<Blocos> blocos = await _blocosRepository.GetAllAsync();
        IEnumerable<BlocosResponse> blocosResponses = _mapper.Map<IEnumerable<BlocosResponse>>(blocos);
        return blocosResponses;
    }

    public async Task<BlocosResponse?> GetByIdTenanteAsync(BlocosPesquisaRequest entity)
    {
        Blocos comando = _mapper.Map<Blocos>(entity);
        Blocos existeBloco = await _blocosRepository.GetByIdTenanteAsync(comando);
        BlocosResponse response = _mapper.Map<BlocosResponse>(existeBloco);
        return response;
    }

    public async Task UpdateAsync(int id, Guid tenante, BlocosAtualizarRequest entity)
    {
        BlocosPesquisaRequest pesquisaRequest = ParsePesquisa(id, tenante);

        Blocos pesquisa = _mapper.Map<Blocos>(pesquisaRequest);
        Blocos existeBloco = await _blocosRepository.GetByIdTenanteAsync(pesquisa);

        if (existeBloco == null)
            return;

        existeBloco.SetNome(entity.Nome);
        existeBloco.SetQuantidadeAndar(entity.QuantidadeAndar);

        await _blocosRepository.UpdateAsync(existeBloco);
    }

    private static BlocosPesquisaRequest ParsePesquisa(int id, Guid tenante)
    {
        return new()
        {
            Id = id,
            Tenante = tenante,
        };
    }
}
