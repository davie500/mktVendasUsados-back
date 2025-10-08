namespace projeto_final_backend.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string Senha_Hash { get; set; }
        public string? Telefone { get; set; }
        public bool Admin { get; set; }
        public int Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
