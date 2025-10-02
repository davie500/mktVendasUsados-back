using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class CarrinhoItemRepository : ICarrinhoItemRepository
    {
        private readonly AppDbContext _context;

        public CarrinhoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarrinhoItem> ListarTodos()
        {
            return _context.CarrinhoItem.ToList();
        }

        public CarrinhoItem ObterPorId(int id)
        {
            return _context.CarrinhoItem.Find(id);
        }

        public void Adicionar(CarrinhoItem carrinhoItem)
        {
            _context.CarrinhoItem.Add(carrinhoItem);
        }

        public void Atualizar(CarrinhoItem carrinhoItem)
        {
            _context.CarrinhoItem.Update(carrinhoItem);
        }

        public void Remover(int id)
        {
            var carrinhoItem = _context.CarrinhoItem.Find(id);
            if (carrinhoItem != null)
                _context.CarrinhoItem.Remove(carrinhoItem);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(CarrinhoItem carrinhoItem)
        {
            _context.CarrinhoItem.Add(carrinhoItem);
            _context.SaveChanges();
        }
    }
}
