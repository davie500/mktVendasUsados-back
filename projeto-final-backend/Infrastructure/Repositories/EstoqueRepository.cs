using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly AppDbContext _context;

        public EstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estoque> ListarTodos()
        {
            return _context.Estoque.ToList();
        }

        public Estoque ObterPorId(int id)
        {
            return _context.Estoque.Find(id);
        }

        public void Adicionar(Estoque estoque)
        {
            _context.Estoque.Add(estoque);
        }

        public void Atualizar(Estoque estoque)
        {
            _context.Estoque.Update(estoque);
        }

        public void Remover(int id)
        {
            var estoque = _context.Estoque.Find(id);
            if (estoque != null)
                _context.Estoque.Remove(estoque);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Estoque estoque)
        {
            _context.Estoque.Add(estoque);
            _context.SaveChanges();
        }
    }
}