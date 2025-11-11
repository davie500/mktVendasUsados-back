using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class VendaService
    {
        private readonly IVendaRepository _repo;

        public VendaService(IVendaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Venda> ObterVendas()
        {
            return _repo.ListarTodos();
        }

        public Venda? ObterVendaPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Venda CriarVenda(Venda venda)
        {
            _repo.Add(venda);
            return venda;
        }

        public Venda AtualizarVenda(Venda venda)
        {
            _repo.Atualizar(venda);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return venda;
        }

        public void RemoverVenda(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}