using Microsoft.AspNetCore.Mvc;
using MyCondo.Application.Services.ApartamentoService.Interface;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.API.Controllers.Apartamento
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentosController : ControllerBase
    {
        private readonly IApartamentosService _apartamentoService;
        private readonly ILogger<ApartamentosController> _logger;

        public ApartamentosController(IApartamentosService apartamentoService, ILogger<ApartamentosController> logger)
        {
            _apartamentoService = apartamentoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtem todos os Apartamentos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<ApartamentosResponse>>> GetAll()
        {
            var Produtoss = await _apartamentoService.GetAllAsync();
            return Ok(Produtoss);
        }

        /// <summary>
        /// Cria um novo Condomínio
        /// </summary>
        /// <param name="Apartamentos"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        public async Task<ActionResult<ApartamentosResponse>> Create(ApartamentosInserirRequest request)
        {
            ApartamentosResponse createdCondominio = await _apartamentoService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdCondominio.Id, createdCondominio.Tenante }, createdCondominio);
        }

        /// <summary>
        /// Busca por um Apartamento informando o Id e o Guid Tenante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenante"></param>
        /// <returns></returns>
        [HttpGet("buscar-id-tenante")]
        public async Task<ActionResult<ApartamentosResponse>> GetById(int id, Guid tenante)
        {
            ApartamentosPesquisaRequest pesquisaRequest = new()
            {
                Id = id,
                Tenante = tenante
            };

            ApartamentosResponse retorno = await _apartamentoService.GetByIdTenanteAsync(pesquisaRequest);
            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }
    }
}
