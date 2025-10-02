namespace projeto_final_backend.Domain.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int? Vendedor_id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
