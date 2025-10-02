using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _repo;

        public PedidoService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            return _repo.ListarTodos();
        }

        public Pedido? ObterPedidoPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Pedido CriarPedido(Pedido pedido)
        {
            _repo.Add(pedido);
            return pedido;
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            _repo.Atualizar(pedido);
            _repo.Salvar(); // Se quiser salvar logo aqui

            return pedido;
        }

        public void RemoverPedido(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }
    }
}