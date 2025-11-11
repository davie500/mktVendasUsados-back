using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<Vendedor> ListarTodos();
        void Add(Vendedor vendedor);
        Vendedor ObterPorId(int id);
        void Atualizar(Vendedor vendedor);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}
