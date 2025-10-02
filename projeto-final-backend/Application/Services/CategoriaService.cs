using projeto_final_backend.Domain.Interfaces;
using tech_store_api.Domain.Entities;

namespace tech_store_api.Application.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaService(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _repo.ListarTodos();
        }

        public Categoria? ObterCategoriaPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Categoria CriarCategoria(Categoria categoria)
        {
            _repo.Add(categoria);
            return categoria;
        }

        public Categoria AtualizarCategoria(Categoria categoria)
        {
            _repo.Atualizar(categoria);
            _repo.Salvar();

            return categoria;
        }

        public void RemoverCategoria(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}
