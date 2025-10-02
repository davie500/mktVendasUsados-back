using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;
using tech_store_api.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> ListarTodos()
        {
            return _context.Categoria.ToList();
        }

        public Categoria ObterPorId(int id)
        {
            return _context.Categoria.Find(id);
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
        }

        public void Remover(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria != null)
                _context.Categoria.Remove(categoria);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
        }
    }
}