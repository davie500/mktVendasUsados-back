using Microsoft.EntityFrameworkCore;
using projeto_final_backend.Domain.Entities;
using tech_store_api.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Comprador> Comprador { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<NomeLoja> NomeLoja { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItem { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
