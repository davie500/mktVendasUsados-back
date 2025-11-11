using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class CompradorService
    {
        private readonly ICompradorRepository _repo;

        public CompradorService(ICompradorRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Comprador> ObterCompradores()
        {
            return _repo.ListarTodos();
        }

        public Comprador? ObterCompradorPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Comprador CriarComprador(Comprador comprador)
        {
            _repo.Add(comprador);
            return comprador;
        }

        public Comprador AtualizarComprador(Comprador comprador)
        {
            _repo.Atualizar(comprador);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return comprador;
        }

        public void RemoverComprador(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}
