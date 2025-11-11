using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class NomeLojaService
    {
        private readonly INomeLojaRepository _repo;

        public NomeLojaService(INomeLojaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<NomeLoja> ObterNomeLoja()
        {
            return _repo.ListarTodos();
        }

        public NomeLoja? ObterNomeLojaPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public NomeLoja CriarNomeLoja(NomeLoja nomeLoja)
        {
            _repo.Add(nomeLoja);
            return nomeLoja;
        }

        public NomeLoja AtualizarNomeLoja(NomeLoja nomeLoja)
        {
            _repo.Atualizar(nomeLoja);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return nomeLoja;
        }

        public void RemoverNomeLoja(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}