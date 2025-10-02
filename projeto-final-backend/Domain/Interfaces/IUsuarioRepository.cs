using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ListarTodos();
        void Add(Usuario usuario);
        Usuario ObterPorId(int id);
        void Atualizar(Usuario usuario);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
        Task<Usuario?> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        Usuario ObterPorEmail(string email);
    }
}