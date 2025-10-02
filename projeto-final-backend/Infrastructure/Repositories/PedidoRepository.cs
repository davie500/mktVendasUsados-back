using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _context.Pedido.ToList();
        }

        public Pedido ObterPorId(int id)
        {
            return _context.Pedido.Find(id);
        }

        public void Adicionar(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedido.Update(pedido);
        }

        public void Remover(int id)
        {
            var pedido = _context.Pedido.Find(id);
            if (pedido != null)
                _context.Pedido.Remove(pedido);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            _context.SaveChanges();
        }
    }
}
