using Microsoft.AspNetCore.Mvc;
using tech_store_api.Application.Services;
using tech_store_api.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;
        public CategoriaController(CategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categorias = _service.ObterCategorias();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest("Categoria inválido.");
            var novaCategoria = _service.CriarCategoria(categoria);

            return CreatedAtAction(nameof(Get), new { id = novaCategoria.Id }, novaCategoria);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria == null || id != categoria.Id)
                return BadRequest("Dados da categoria inválidos.");

            var categoriaExistente = _service.ObterCategoriaPorId(id);
            if (categoriaExistente == null)
                return NotFound();

            _service.AtualizarCategoria(categoria);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _service.ObterCategoriaPorId(id);
            if (categoria == null)
                return NotFound();

            _service.RemoverCategoria(id);

            return NoContent();
        }
    }
}