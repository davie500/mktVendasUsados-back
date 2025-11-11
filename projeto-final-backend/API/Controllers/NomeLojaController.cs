using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NomeLojaController : ControllerBase
    {
        private readonly NomeLojaService _service;

        public NomeLojaController(NomeLojaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var nomeLojas = _service.ObterNomeLoja();
            return Ok(nomeLojas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NomeLoja nomeLoja)
        {
            if (nomeLoja == null)
                return BadRequest("Nome da loja inválido.");
            var novoNomeLoja = _service.CriarNomeLoja(nomeLoja);

            return CreatedAtAction(nameof(Get), new { id = nomeLoja.Id }, nomeLoja);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NomeLoja nomeLoja)
        {
            if (nomeLoja == null || id != nomeLoja.Id)
                return BadRequest("Dados do nome da loja inválidos.");

            var nomeLojaExistente = _service.ObterNomeLojaPorId(id);
            if (nomeLojaExistente == null)
                return NotFound();

            _service.AtualizarNomeLoja(nomeLoja);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var nomeLoja = _service.ObterNomeLojaPorId(id);
            if (nomeLoja == null)
                return NotFound();

            _service.RemoverNomeLoja(id);

            return NoContent();
        }
    }
}
