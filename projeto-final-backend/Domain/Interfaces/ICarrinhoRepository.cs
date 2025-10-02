using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface ICarrinhoRepository
    {
        IEnumerable<Carrinho> ListarTodos();
        void Add(Carrinho carrinho);
        Carrinho ObterPorId(int id);
        //void Update(Fornecedor fornecedor);
        void Atualizar(Carrinho carrinho);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}
