using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly CompradorService _service;

        public VendedorController(VendedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vendedores = _service.ObterVendedores();
            return Ok(vendedores);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vendedor vendedor)
        {
            if (vendedor == null)
                return BadRequest("Vendedor inválido.");
            var novoVendedor = _service.CriarVendedor(vendedor);

            return CreatedAtAction(nameof(Get), new { id = novoVendedor.Id }, novoVendedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vendedor vendedor)
        {
            if (vendedor == null || id != vendedor.Id)
                return BadRequest("Dados do vendedor inválidos.");

            var VendedorExistente = _service.ObterVendedorPorId(id);
            if (VendedorExistente == null)
                return NotFound();

            _service.AtualizarVendedor(vendedor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vendedor = _service.ObterVendedorPorId(id);
            if (vendedor == null)
                return NotFound();

            _service.RemoverVendedor(id);

            return NoContent();
        }
    }
}