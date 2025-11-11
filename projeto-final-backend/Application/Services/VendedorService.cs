using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class VendedorService
    {
        private readonly IVendedorRepository _repo;

        public VendedorService(IVendedorRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Vendedor> ObterVendedores()
        {
            return _repo.ListarTodos();
        }

        public Vendedor? ObterVendedorPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Vendedor CriarVendedor(Vendedor vendedor)
        {
            _repo.Add(vendedor);
            return vendedor;
        }

        public Vendedor AtualizarVendedor(Vendedor vendedor)
        {
            _repo.Atualizar(vendedor);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return vendedor;
        }

        public void RemoverVendedor(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}
