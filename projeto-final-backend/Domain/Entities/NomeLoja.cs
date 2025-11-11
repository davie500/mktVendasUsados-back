namespace projeto_final_backend.Domain.Entities
{
    public class NomeLoja
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int VendedorId { get; set; }
        public string? Endereco { get; set; }
        public string? Contato { get; set; }
    }
}
