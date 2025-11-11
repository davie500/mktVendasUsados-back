using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Venda> ListarTodos()
        {
            return _context.Venda.ToList();
        }

        public Venda ObterPorId(int id)
        {
            return _context.Venda.Find(id);
        }

        public void Adicionar(Venda venda)
        {
            _context.Venda.Add(venda);
        }

        public void Atualizar(Venda venda)
        {
            _context.Venda.Update(venda);
        }

        public void Remover(int id)
        {
            var venda = _context.Venda.Find(id);
            if (venda != null)
                _context.Venda.Remove(venda);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }
    }
}
