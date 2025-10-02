using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _repo;

        public CarrinhoService(ICarrinhoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Carrinho> ObterCarrinhos()
        {
            return _repo.ListarTodos();
        }

        public Carrinho? ObterCarrinhoPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Carrinho CriarCarrinho(Carrinho carrinho)
        {
            _repo.Add(carrinho);
            return carrinho;
        }

        public Carrinho AtualizarCarrinho(Carrinho carrinho)
        {
            _repo.Atualizar(carrinho);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return carrinho;
        }

        public void RemoverCarrinho(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}