namespace projeto_final_backend.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Unitario { get; set; }
        public decimal Valor_Total { get; set; }
        public DateTime Data_Venda { get; set; }
        public int ProdutoId { get; set; }
        public int CompradorId { get; set; }
        public string Metodo_Pagamento { get; set; }
    }
}
