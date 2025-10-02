using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class CarrinhoItemService
    {
        private readonly ICarrinhoItemRepository _repo;

        public CarrinhoItemService(ICarrinhoItemRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CarrinhoItem> ObterCarrinhoItem()
        {
            return _repo.ListarTodos();
        }

        public CarrinhoItem? ObterCarrinhoItemPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public CarrinhoItem CriarCarrinhoItem(CarrinhoItem carrinhoItem)
        {
            _repo.Add(carrinhoItem);
            return carrinhoItem;
        }

        public CarrinhoItem AtualizarCarrinhoItem(CarrinhoItem carrinhoItem)
        {
            _repo.Atualizar(carrinhoItem);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return carrinhoItem;
        }

        public void RemoverCarrinhoItem(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}