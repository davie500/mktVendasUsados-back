using tech_store_api.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ListarTodos();
        void Add(Categoria categoria);
        Categoria ObterPorId(int id);
        void Atualizar(Categoria categoria);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}
