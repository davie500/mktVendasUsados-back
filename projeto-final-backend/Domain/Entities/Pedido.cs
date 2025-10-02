namespace projeto_final_backend.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int? Vendedor_Id { get; set; }
        public int? Comprador_Id { get; set; }
        public int? Status { get; set; } = 0;
        public string MetodoPagamento { get; set; }
        public decimal Total { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
