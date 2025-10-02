namespace tech_store_api.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public int? Ativa { get; set; } = 0;
    }
}
