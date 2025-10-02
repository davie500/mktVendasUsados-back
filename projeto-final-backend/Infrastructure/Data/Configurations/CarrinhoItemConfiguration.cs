using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data.Configurations
{
    public class CarrinhoItemConfiguration : IEntityTypeConfiguration<CarrinhoItem>
    {
        public void Configure(EntityTypeBuilder<CarrinhoItem> builder)
        {
            builder.ToTable("carrinhoItem");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired().HasMaxLength(100);
        }
    }
}
