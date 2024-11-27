using Microsoft.AspNetCore.Mvc;
using MyCondo.Application.Services.BlocoService.Interface;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.API.Controllers.Bloco
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlocosController : ControllerBase
    {
        private readonly IBlocosService _blocoService;
        private readonly ILogger<BlocosController> _logger;

        public BlocosController(IBlocosService blocoService, ILogger<BlocosController> logger)
        {
            _blocoService = blocoService;
            _logger = logger;
        }

        /// <summary>
        /// Cria um novo Condomínio
        /// </summary>
        /// <param name="Blocos"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        public async Task<ActionResult<CondominiosResponse>> Create(BlocosInserirRequest request)
        {
            BlocosResponse createdCondominio = await _blocoService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdCondominio.Id, createdCondominio.Tenante }, createdCondominio);
        }

        /// <summary>
        /// Busca por um Bloco informando o Id e o Guid Tenante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpGet("buscar-id-tenante")]
        public async Task<ActionResult<BlocosResponse>> GetById(int id, Guid tenante)
        {
            BlocosPesquisaRequest pesquisaRequest = new()
            {
                Id = id,
                Tenante = tenante
            };

            BlocosResponse retorno = await _blocoService.GetByIdTenanteAsync(pesquisaRequest);
            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }

        /// <summary>
        /// Atualiza um Bloco já previamente cadastrado
        /// </summary>
        /// <param name="Blocos"></param>
        /// <returns></returns>
        [HttpPut("atualizar")]
        public async Task<IActionResult> Update(int Id, Guid Tenante, [FromBody] BlocosAtualizarRequest entity)
        {
            if (string.IsNullOrEmpty(entity.Nome))
                return BadRequest();

            await _blocoService.UpdateAsync(Id, Tenante, entity);
            return NoContent();
        }

        /// <summary>
        /// Delete um Bloco cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpDelete("deletar")]
        public async Task<IActionResult> Delete(int id, Guid tenante)
        {
            BlocosExcluirRequest blocosExcluirRequest = new()
            {
                Id = id,
                Tenante = tenante
            };
            await _blocoService.DeleteAsync(blocosExcluirRequest);
            return NoContent();
        }
    }
}
