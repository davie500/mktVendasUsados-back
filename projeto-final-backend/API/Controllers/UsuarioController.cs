using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _service.ObterUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Usuário inválido.");
            var novoUsuario = _service.CriarUsuario(usuario);

            return CreatedAtAction(nameof(Get), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
                return BadRequest("Dados do usuário inválidos.");

            var usuarioExistente = _service.ObterUsuarioPorId(id);
            if (usuarioExistente == null)
                return NotFound();

            _service.AtualizarUsuario(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _service.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound();

            _service.RemoverUsuario(id);

            return NoContent();
        }
    }
}
