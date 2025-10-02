using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface ICarrinhoItemRepository
    {
        IEnumerable<CarrinhoItem> ListarTodos();
        void Add(CarrinhoItem carrinhoItem);
        CarrinhoItem ObterPorId(int id);
        //void Update(Fornecedor fornecedor);
        void Atualizar(CarrinhoItem carrinhoItem);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}