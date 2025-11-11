using System.Globalization;

namespace projeto_final_backend.Domain.Entities
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime Criado_Em { get; set; }
    }
}
