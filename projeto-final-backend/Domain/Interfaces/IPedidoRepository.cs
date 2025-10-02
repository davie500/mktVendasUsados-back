using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> ListarTodos();
        void Add(Pedido pedido);
        Pedido ObterPorId(int id);
        void Atualizar(Pedido pedido);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}