using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class NomeLojaRepository : INomeLojaRepository
    {
        private readonly AppDbContext _context;

        public NomeLojaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NomeLoja> ListarTodos()
        {
            return _context.NomeLoja.ToList();
        }

        public NomeLoja ObterPorId(int id)
        {
            return _context.NomeLoja.Find(id);
        }

        public void Adicionar(NomeLoja nomeLoja)
        {
            _context.NomeLoja.Add(nomeLoja);
        }

        public void Atualizar(NomeLoja nomeLoja)
        {
            _context.NomeLoja.Update(nomeLoja);
        }

        public void Remover(int id)
        {
            var nomeLoja = _context.NomeLoja.Find(id);
            if (nomeLoja != null)
                _context.NomeLoja.Remove(nomeLoja);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(NomeLoja nomeLoja)
        {
            _context.NomeLoja.Add(nomeLoja);
            _context.SaveChanges();
        }
    }
}
