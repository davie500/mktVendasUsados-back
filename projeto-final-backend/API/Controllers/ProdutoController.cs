using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Services;
using projeto_final_backend.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _service.ObterProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Produto inválido.");
            var novoProduto = _service.CriarProduto(produto);

            return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (produto == null || id != produto.Id)
                return BadRequest("Dados do usuário inválidos.");

            var produtoExistente = _service.ObterProdutoPorId(id);
            if (produtoExistente == null)
                return NotFound();

            _service.AtualizarProduto(produto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _service.ObterProdutoPorId(id);
            if (produto == null)
                return NotFound();

            _service.RemoverProduto(id);

            return NoContent();
        }
    }
}
