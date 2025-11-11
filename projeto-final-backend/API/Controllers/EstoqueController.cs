using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _service;

        public EstoqueController(EstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var estoques = _service.ObterEstoques();
            return Ok(estoques);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estoque estoque)
        {
            if (estoque == null)
                return BadRequest("Estoque inválido.");
            var novoEstoque = _service.CriarEstoque(estoque);

            return CreatedAtAction(nameof(Get), new { id = novoEstoque.Id }, novoEstoque);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estoque estoque)
        {
            if (estoque == null || id != estoque.Id)
                return BadRequest("Dados do estoque inválidos.");

            var estoqueExistente = _service.ObterEstoquePorId(id);
            if (estoqueExistente == null)
                return NotFound();

            _service.AtualizarEstoque(estoque);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estoque = _service.ObterEstoquePorId(id);
            if (estoque == null)
                return NotFound();

            _service.RemoverEstoque(id);

            return NoContent();
        }
    }
}
