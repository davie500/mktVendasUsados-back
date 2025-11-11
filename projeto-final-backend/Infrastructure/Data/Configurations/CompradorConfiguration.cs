using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data.Configurations
{
    public class CompradorConfiguration : IEntityTypeConfiguration<Comprador>
    {
        public void Configure(EntityTypeBuilder<Comprador> builder)
        {
            builder.ToTable("comprador");
            builder.HasKey(co => co.Id);
            builder.Property(co => co.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
