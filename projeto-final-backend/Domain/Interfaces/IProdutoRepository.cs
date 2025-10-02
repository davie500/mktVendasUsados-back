using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ListarTodos();
        void Add(Produto produto);
        Produto ObterPorId(int id);
        void Atualizar(Produto produto);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}
