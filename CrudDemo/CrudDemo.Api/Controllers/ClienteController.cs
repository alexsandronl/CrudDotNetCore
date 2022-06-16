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

        [HttpPost]
        public IActionResult Novo([FromBody] Cliente registro)
        {
            if (registro == null)
                return NotFound();

            if (registro.IndicadorRegistroNovo)
                return BadRequest("É necessário que seja um novo registro");

            return Execute(() => _clienteService.Salvar<ClienteValidation>(registro));
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Cliente registro)
        {
            if (registro == null)
                return NotFound();

            if (registro.IndicadorRegistroNovo)
                return BadRequest("Não é permitido um registro novo");

            return Execute(() => _clienteService.Salvar<ClienteValidation>(registro));
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id)
        {
            if (id == default)
                return NotFound();

            Execute(() =>
            {
                _clienteService.Excluir(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Buscatodos()
        {
            return Execute(() => _clienteService.BuscaTodos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == default)
                return NotFound();

            return Execute(() => _clienteService.BuscaPorId(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
