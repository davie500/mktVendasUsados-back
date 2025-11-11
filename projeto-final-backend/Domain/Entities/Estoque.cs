namespace projeto_final_backend.Domain.Entities
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco_Produtos { get; set; }
    }
}
