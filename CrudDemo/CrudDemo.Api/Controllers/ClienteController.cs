using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.Servico.Validations;
using Microsoft.AspNetCore.Mvc;

namespace CrudDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IServicoCRUD<Cliente> _clienteService;

        public ClienteController(IServicoCRUD<Cliente> clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscaTodos()
        {
            try
            {
                var lista = await _clienteService.BuscaTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == default)
                return NotFound();

            try
            {
                return Ok(await _clienteService.BuscaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Novo([FromBody] Cliente registro)
        {
            if (registro == null)
                return NotFound();

            if (!registro.IndicadorRegistroNovo)
                return BadRequest("É necessário que seja um novo registro");

            try
            {
                return Ok(await _clienteService.Salvar<ClienteValidation>(registro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Cliente registro)
        {
            if (registro == null)
                return NotFound();

            if (registro.IndicadorRegistroNovo)
                return BadRequest("Não é permitido um registro novo");
            try
            {
                return Ok(await _clienteService.Salvar<ClienteValidation>(registro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            if (id == default)
                return NotFound();

            try
            {
                await _clienteService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
