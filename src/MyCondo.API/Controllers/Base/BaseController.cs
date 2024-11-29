using Microsoft.AspNetCore.Mvc;
using MyCondo.Application.Services.Base;

namespace MyCondo.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse> : ControllerBase
         where TPesquisa : class
         where TInserir : class
         where TAtualizar : class
         where TDeletar : class
         where TResponse : class
    {
        protected readonly IBaseService<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse> _service;
        protected readonly ILogger<BaseController<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse>> _logger;

        protected BaseController(IBaseService<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse> service,
                                 ILogger<BaseController<TPesquisa, TInserir, TAtualizar, TDeletar, TResponse>> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obtem todos os dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("obter-todos")]
        public virtual async Task<ActionResult<IEnumerable<TResponse>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        /// <summary>
        /// Criar um novo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        public virtual async Task<ActionResult<TResponse>> Create([FromBody] TInserir request)
        {
            var tenanteProperty = request.GetType().GetProperty("Tenante");
            var idProperty = request.GetType().GetProperty("Id");

            var entity = await _service.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = idProperty, tenanteProperty }, entity);
        }

        /// <summary>
        /// Buscar por id e tenante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpGet("buscar-id")]
        public virtual async Task<ActionResult<TResponse>> GetById(int id, Guid tenante)
        {
            TPesquisa pesquisaRequest = Activator.CreateInstance<TPesquisa>(); // Instancia uma pesquisa padrão (ajustar conforme sua necessidade)
            // Defina os parâmetros de pesquisa, por exemplo:
            // pesquisaRequest.Id = id;
            // pesquisaRequest.Tenante = tenante;

            var entity = await _service.GetByIdTenanteAsync(pesquisaRequest);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Atualizar um dado existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("atualizar")]
        public virtual async Task<IActionResult> Update(int id, Guid tenante, [FromBody] TAtualizar request)
        {
            await _service.UpdateAsync(id, tenante, request);
            return NoContent();
        }

        /// <summary>
        /// Excluir um dado existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpDelete("deletar")]
        public virtual async Task<IActionResult> Delete(int id, Guid tenante)
        {
            TDeletar deleteRequest = Activator.CreateInstance<TDeletar>(); // Instancia um objeto de deletação
            // Defina os parâmetros de deletação, por exemplo:
            // deleteRequest.Id = id;
            // deleteRequest.Tenante = tenante;

            await _service.DeleteAsync(deleteRequest);
            return NoContent();
        }
    }
}
