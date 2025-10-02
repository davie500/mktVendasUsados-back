using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.HasKey(pe => pe.Id);
            builder.Property(pe => pe.Id).IsRequired().HasMaxLength(100);
        }
    }
}