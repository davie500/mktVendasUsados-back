namespace projeto_final_backend.Domain.Entities
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public int Carrinho_Id { get; set; }
        public int Produto_Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
