using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly AppDbContext _context;

        public VendedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vendedor> ListarTodos()
        {
            return _context.Vendedor.ToList();
        }

        public Vendedor ObterPorId(int id)
        {
            return _context.Vendedor.Find(id);
        }

        public void Adicionar(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
        }

        public void Atualizar(Vendedor vendedor)
        {
            _context.Vendedor.Update(vendedor);
        }

        public void Remover(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor != null)
                _context.Vendedor.Remove(vendedor);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
        }
    }
}