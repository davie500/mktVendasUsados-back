using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Domain.Interfaces
{
    public interface INomeLojaRepository
        {
        IEnumerable<NomeLoja> ListarTodos();
        void Add(NomeLoja nomeLoja);
        NomeLoja ObterPorId(int id);
        //void Update(Fornecedor fornecedor);
        void Atualizar(NomeLoja nomeLoja);
        //Produto ObterPorId(int id);
        //void Adicionar(Produto produto);
        //void Atualizar(Produto produto);
        //void Remover(int id);

        void Remover(int id);
        void Salvar(); // Ou SaveChanges()
    }
}