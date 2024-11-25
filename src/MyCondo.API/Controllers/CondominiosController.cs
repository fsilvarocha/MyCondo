using Microsoft.AspNetCore.Mvc;
using MyCondo.Application.Services.CondominioService.Interface;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominiosController : ControllerBase
    {
        private readonly ICondominiosService _condominioService;
        private readonly ILogger<CondominiosController> _logger;

        public CondominiosController(ICondominiosService condominioService, ILogger<CondominiosController> logger)
        {
            _condominioService = condominioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtem todos os condominios cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<CondominiosResponse>>> GetAll()
        {
            var Produtoss = await _condominioService.GetAllAsync();
            return Ok(Produtoss);
        }

        /// <summary>
        /// Cria um novo Condomínio
        /// </summary>
        /// <param name="Produtos"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        public async Task<ActionResult<CondominiosResponse>> Create(CondominiosInserirRequest request)
        {
            CondominiosResponse createdCondominio = await _condominioService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdCondominio.Id, createdCondominio.Tenante }, createdCondominio);
        }

        /// <summary>
        /// Busca por um produto informando o Id e o Guid Tenante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpGet("buscar-id-tenante")]
        public async Task<ActionResult<CondominiosResponse>> GetById(int id, Guid tenante)
        {
            CondominiosPesquisaRequest pesquisaRequest = new()
            {
                Id = id,
                Tenante = tenante
            };

            CondominiosResponse retorno = await _condominioService.GetByIdTenanteAsync(pesquisaRequest);
            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }
    }
}
