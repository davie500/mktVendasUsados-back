using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly AppDbContext _context;

        public CarrinhoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Carrinho> ListarTodos()
        {
            return _context.Carrinho.ToList();
        }

        public Carrinho ObterPorId(int id)
        {
            return _context.Carrinho.Find(id);
        }

        public void Adicionar(Carrinho carrinho)
        {
            _context.Carrinho.Add(carrinho);
        }

        public void Atualizar(Carrinho carrinho)
        {
            _context.Carrinho.Update(carrinho);
        }

        public void Remover(int id)
        {
            var carrinho = _context.Carrinho.Find(id);
            if (carrinho != null)
                _context.Carrinho.Remove(carrinho);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Carrinho carrinho)
        {
            _context.Carrinho.Add(carrinho);
            _context.SaveChanges();
        }
    }
}
