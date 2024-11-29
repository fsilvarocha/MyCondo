using Microsoft.AspNetCore.Mvc;
using MyCondo.Application.Services.MoradorService.Interface;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;

namespace MyCondo.API.Controllers.Morador
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradoresController : ControllerBase
    {
        private readonly IMoradoresService _moradorService;
        private readonly ILogger<MoradoresController> _logger;

        public MoradoresController(IMoradoresService moradorService, ILogger<MoradoresController> logger)
        {
            _moradorService = moradorService;
            _logger = logger;
        }


        /// <summary>
        /// Obtem todos os Moradores cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<MoradoresResponse>>> GetAll()
        {
            IEnumerable<MoradoresResponse> listaMoradores = await _moradorService.GetAllAsync();
            return Ok(listaMoradores);
        }

        /// <summary>
        /// Cria um novo Morador
        /// </summary>
        /// <param name="Apartamentos"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        public async Task<ActionResult<MoradoresResponse>> Create(MoradoresInserirRequest request)
        {
            MoradoresResponse createdCondominio = await _moradorService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdCondominio.Id, createdCondominio.Tenante }, createdCondominio);
        }

        /// <summary>
        /// Busca por um Morador informando o Id e o Guid Tenante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpGet("buscar-id-tenante")]
        public async Task<ActionResult<MoradoresResponse>> GetById(int id, Guid tenante)
        {
            MoradoresPesquisaRequest pesquisaRequest = new()
            {
                Id = id,
                Tenante = tenante
            };

            MoradoresResponse retorno = await _moradorService.GetByIdTenanteAsync(pesquisaRequest);
            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }

        /// <summary>
        /// Atualiza um morador já previamente cadastrado
        /// </summary>
        /// <param name="Condominio"></param>
        /// <returns></returns>
        [HttpPut("atualizar")]
        public async Task<IActionResult> Update(int Id, Guid Tenante, [FromBody] MoradoresAtualizarRequest entity)
        {
            if (string.IsNullOrEmpty(entity.Nome))
                return BadRequest();

            await _moradorService.UpdateAsync(Id, Tenante, entity);
            return NoContent();
        }

        /// <summary>
        /// Delete um Morador cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpDelete("deletar")]
        public async Task<IActionResult> Delete(int id, Guid tenante)
        {
            MoradoresExcluirRequest request = new()
            {
                Id = id,
                Tenante = tenante
            };

            await _moradorService.DeleteAsync(request);
            return NoContent();
        }
    }
}
