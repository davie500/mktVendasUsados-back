using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;
        public PedidoController(PedidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _service.ObterPedidos();
            return Ok(pedidos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest("Pedido inválido.");
            var novoPedido = _service.CriarPedido(pedido);

            return CreatedAtAction(nameof(Get), new { id = novoPedido.Id }, novoPedido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (pedido == null || id != pedido.Id)
                return BadRequest("Dados do pedido inválidos.");

            var pedidoExistente = _service.ObterPedidoPorId(id);
            if (pedidoExistente == null)
                return NotFound();

            _service.AtualizarPedido(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _service.ObterPedidoPorId(id);
            if (pedido == null)
                return NotFound();

            _service.RemoverPedido(id);

            return NoContent();
        }
    }
}
