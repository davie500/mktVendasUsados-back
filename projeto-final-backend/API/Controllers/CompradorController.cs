using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompradorController : ControllerBase
    {
        private readonly CompradorService _service;

        public CompradorController(CompradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var compradores = _service.ObterCompradores();
            return Ok(compradores);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comprador comprador)
        {
            if (comprador == null)
                return BadRequest("Comprador inválido.");
            var novoComprador = _service.CriarComprador(comprador);

            return CreatedAtAction(nameof(Get), new { id = novoComprador.Id }, novoComprador);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comprador comprador)
        {
            if (comprador == null || id != comprador.Id)
                return BadRequest("Dados do usuário inválidos.");

            var CompradorExistente = _service.ObterCompradorPorId(id);
            if (CompradorExistente == null)
                return NotFound();

            _service.AtualizarComprador(comprador);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comprador = _service.ObterCompradorPorId(id);
            if (comprador == null)
                return NotFound();

            _service.RemoverComprador(id);

            return NoContent();
        }
    }
}