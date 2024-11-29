using AutoMapper;
using MyCondo.Domain.Interface.Base;
using MyCondo.Domain.Transfer.DataTransfer.Base.Interface;

namespace MyCondo.Application.Services.Base;

public abstract class BaseService<TEntity, TPesquisa, TInserir, TAtualizar, TDeletar, TResponse>
    : IBaseService<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse>
    where TEntity : class
    where TPesquisa : class, IPesquisaBase, new()
    where TInserir : class
    where TAtualizar : class
    where TDeletar : class
    where TResponse : class
{
    protected readonly IMapper _mapper;
    protected readonly IBaseRepository<TEntity> _repository;

    protected BaseService(IMapper mapper, IBaseRepository<TEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public virtual async Task<TResponse?> GetByIdTenanteAsync(TPesquisa entity)
    {
        TEntity pesquisa = _mapper.Map<TEntity>(entity);
        var result = await _repository.GetByIdTenanteAsync(pesquisa);
        return _mapper.Map<TResponse>(result);
    }

    public virtual async Task<IEnumerable<TResponse>> GetAllAsync()
    {
        IEnumerable<TEntity> entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TResponse>>(entities);
    }

    public virtual async Task<TResponse> AddAsync(TInserir entity)
    {
        TEntity model = _mapper.Map<TEntity>(entity);
        await _repository.AddAsync(model);
        return _mapper.Map<TResponse>(model);
    }

    public virtual async Task UpdateAsync(int id, Guid tenante, TAtualizar entity)
    {
        TPesquisa pesquisa = ParsePesquisa<TPesquisa>(id, tenante);

        TEntity? existente = await _repository.GetByIdTenanteAsync(_mapper.Map<TEntity>(pesquisa));
        if (existente == null)
            throw new KeyNotFoundException($"{typeof(TEntity).Name} não encontrada para atualização.");

        _mapper.Map(entity, existente);

        await _repository.UpdateAsync(existente);
    }


    public virtual async Task DeleteAsync(TDeletar entity)
    {
        TPesquisa pesquisa = _mapper.Map<TPesquisa>(entity);

        TEntity? existente = await _repository.GetByIdTenanteAsync(_mapper.Map<TEntity>(pesquisa));

        if (existente == null)
            throw new KeyNotFoundException($"{typeof(TEntity).Name} não encontrada para exclusão.");

        await _repository.DeleteAsync(existente);
    }


    private static TPesquisaBase ParsePesquisa<TPesquisaBase>(int id, Guid tenante)
        where TPesquisaBase : class, IPesquisaBase, new()
    {
        return new TPesquisaBase
        {
            Id = id,
            Tenante = tenante,
        };
    }
}
