using Microsoft.EntityFrameworkCore;
using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;
using projeto_final_backend.Infrastructure.Data;

namespace projeto_final_backend.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _context.Usuario.ToList();
        }

        public Usuario? ObterPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
        }

        public void Remover(int id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario != null)
                _context.Usuario.Remove(usuario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Task<Usuario?> GetByEmailAsync(string email)
        {
            return _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task AddAsync(Usuario usuario)
        {
            _context.Usuario.AddAsync(usuario);
            return _context.SaveChangesAsync();
        }
        public Usuario ObterPorEmail(string email)
        {
            var emailNormalizado = email.Trim().ToLower();
            return _context.Usuario.FirstOrDefault(u => u.Email.ToLower() == emailNormalizado);
        }

    }
}
