using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoItemController : ControllerBase
    {
        private readonly CarrinhoItemService _service;
        public CarrinhoItemController(CarrinhoItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var carrinhoItens = _service.ObterCarrinhoItem();
            return Ok(carrinhoItens);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CarrinhoItem carrinhoItem)
        {
            if (carrinhoItem == null)
                return BadRequest("Item do carrinho inválido.");
            var novoCarrinhoItem = _service.CriarCarrinhoItem(carrinhoItem);

            return CreatedAtAction(nameof(Get), new { id = novoCarrinhoItem.Id }, novoCarrinhoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarrinhoItem carrinhoItem)
        {
            if (carrinhoItem == null || id != carrinhoItem.Id)
                return BadRequest("Dados do item do carrinho inválidos.");

            var carrinhoItemExistente = _service.ObterCarrinhoItemPorId(id);
            if (carrinhoItemExistente == null)
                return NotFound();

            _service.AtualizarCarrinhoItem(carrinhoItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carrinhoItem = _service.ObterCarrinhoItemPorId(id);
            if (carrinhoItem == null)
                return NotFound();

            _service.RemoverCarrinhoItem(id);

            return NoContent();
        }
    }
}
