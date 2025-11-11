using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface ICompradorRepository
    {
        IEnumerable<Comprador> ListarTodos();
        void Add(Comprador comprador);
        Comprador ObterPorId(int id);
        void Atualizar(Comprador comprador);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}
