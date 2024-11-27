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

    public async Task UpdateAsync(int id, Guid tenante, CondominiosAtualizarRequest entity)
    {
        CondominiosPesquisaRequest requestPesquisa = ParsePesquisa(id, tenante);

        Condominios pesquisa = _mapper.Map<Condominios>(requestPesquisa);

        Condominios existingProdutos = await _condominiosRepository.GetByIdTenanteAsync(pesquisa);

        if (existingProdutos == null)
            return;

        SetarCondominioNovo(entity, existingProdutos);

        await _condominiosRepository.UpdateAsync(existingProdutos);
    }

    public async Task DeleteAsync(int id, Guid tenante)
    {
        CondominiosPesquisaRequest requestPesquisa = ParsePesquisa(id, tenante);

        Condominios pesquisa = _mapper.Map<Condominios>(requestPesquisa);

        Condominios existingProdutos = await _condominiosRepository.GetByIdTenanteAsync(pesquisa);

        if (existingProdutos == null)
            return;        

        await _condominiosRepository.DeleteAsync(existingProdutos);
    }

    private static void SetarCondominioNovo(CondominiosAtualizarRequest entity, Condominios existingProdutos)
    {
        existingProdutos.SetNome(entity.Nome);
        existingProdutos.SetCnpj(entity.Cnpj);
        existingProdutos.SetTipoCondominio(entity.TipoCondominio);
        existingProdutos.SetLogo(entity.Logo);
        existingProdutos.SetCep(entity.Cep);
        existingProdutos.SetCidade(entity.Cidade);
        existingProdutos.SetUf(entity.Uf);
        existingProdutos.SetBairro(entity.Bairro);
        existingProdutos.SetLogradouro(entity.Logradouro);
        existingProdutos.SetNumero(entity.Numero);
        existingProdutos.SetComplemento(entity.Complemento);
        existingProdutos.SetDataAtualizado(DateTime.Now);
    }

    private static CondominiosPesquisaRequest ParsePesquisa(int id, Guid tenante)
    {
        return new()
        {
            Id = id,
            Tenante = tenante,
        };
    }
}
