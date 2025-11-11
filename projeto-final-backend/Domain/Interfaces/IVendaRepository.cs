using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface IVendaRepository
    {
        public interface IVendaRepository
        {
            IEnumerable<Venda> ListarTodos();
            void Add(Venda venda);
            Venda ObterPorId(int id);
            void Atualizar(Venda venda);
            //Produto ObterPorId(int id);
            //void Adicionar(Produto produto);
            //void Atualizar(Produto produto);
            //void Remover(int id);

            void Remover(int id);
            void Salvar(); // Ou SaveChanges()
        }
    }
}
