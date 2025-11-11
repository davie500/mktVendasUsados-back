using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class CompradorRepository : ICompradorRepository
    {
        private readonly AppDbContext _context;

        public CompradorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comprador> ListarTodos()
        {
            return _context.Comprador.ToList();
        }

        public Comprador ObterPorId(int id)
        {
            return _context.Comprador.Find(id);
        }

        public void Adicionar(Comprador comprador)
        {
            _context.Comprador.Add(comprador);
        }

        public void Atualizar(Comprador comprador)
        {
            _context.Comprador.Update(comprador);
        }

        public void Remover(int id)
        {
            var comprador = _context.Comprador.Find(id);
            if (comprador != null)
                _context.Comprador.Remove(comprador);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Comprador comprador)
        {
            _context.Comprador.Add(comprador);
            _context.SaveChanges();
        }
    }
}