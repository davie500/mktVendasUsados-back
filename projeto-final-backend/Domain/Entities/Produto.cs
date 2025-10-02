using System.Reflection.Metadata;

namespace projeto_final_backend.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public int Vendedor_Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int? Estoque { get; set; }
        public byte[] Imagem { get; set; }
        public int? Status { get; set; } = 0;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
