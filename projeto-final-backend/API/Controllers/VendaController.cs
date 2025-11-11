using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _service;
        public VendaController(VendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vendas = _service.ObterVendas();
            return Ok(vendas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vendas venda)
        {
            if (venda == null)
                return BadRequest("Venda inválida.");
            var novaVenda = _service.CriarVenda(venda);

            return CreatedAtAction(nameof(Get), new { id = novaVenda.Id }, novaVenda);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Venda venda)
        {
            if (venda == null || id != venda.Id)
                return BadRequest("Dados da venda inválidos.");

            var vendaExistente = _service.ObterVendaPorId(id);
            if (vendaExistente == null)
                return NotFound();

            _service.AtualizarVenda(venda);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var venda = _service.ObterVendaPorId(id);
            if (venda == null)
                return NotFound();

            _service.RemoverVenda(id);

            return NoContent();
        }
    }
}
