using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        public interface IEstoqueRepository
        {
            IEnumerable<Estoque> ListarTodos();
            void Add(Estoque estoque);
            Estoque ObterPorId(int id);
            void Atualizar(Estoque estoque);
            //Produto ObterPorId(int id);
            //void Adicionar(Produto produto);
            //void Atualizar(Produto produto);
            //void Remover(int id);

            void Remover(int id);
            void Salvar(); // Ou SaveChanges()
        }
    }
}
