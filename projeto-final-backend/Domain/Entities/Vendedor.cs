namespace projeto_final_backend.Domain.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Criado_Em { get; set; } = DateTime.UtcNow;
    }
}
