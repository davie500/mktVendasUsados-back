using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data.Configurations
{
    public class CarrinhoConfiguration : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("carrinho");
            builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.Id).IsRequired().HasMaxLength(100);
        }
    }
}
