using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly CarrinhoService _service;
        public CarrinhoController(CarrinhoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var carrinhos = _service.ObterCarrinhos();
            return Ok(carrinhos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Carrinho carrinho)
        {
            if (carrinho == null)
                return BadRequest("Carrinho inválido.");
            var novoCarrinho = _service.CriarCarrinho(carrinho);

            return CreatedAtAction(nameof(Get), new { id = novoCarrinho.Id }, novoCarrinho);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Carrinho carrinho)
        {
            if (carrinho == null || id != carrinho.Id)
                return BadRequest("Dados do carrinho inválidos.");

            var carrinhoExistente = _service.ObterCarrinhoPorId(id);
            if (carrinhoExistente == null)
                return NotFound();

            _service.AtualizarCarrinho(carrinho);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carrinho = _service.ObterCarrinhoPorId(id);
            if (carrinho == null)
                return NotFound();

            _service.RemoverCarrinho(id);

            return NoContent();
        }
    }
}