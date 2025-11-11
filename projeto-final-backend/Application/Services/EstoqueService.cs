using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _repo;

        public EstoqueService(IEstoqueRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Estoque> ObterEstoques()
        {
            return _repo.ListarTodos();
        }

        public Estoque? ObterEstoquePorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Estoque CriarProduto(Estoque estoque)
        {
            _repo.Add(estoque);
            return estoque;
        }

        public Estoque AtualizarEstoque(Estoque estoque)
        {
            _repo.Atualizar(estoque);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return estoque;
        }

        public void RemoverEstoque(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}
