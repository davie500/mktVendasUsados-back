using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_final_backend.Domain.Entities;

namespace projeto_final_backend.Infrastructure.Data.Configurations
{
    public class NomeLojaConfiguration : IEntityTypeConfiguration<NomeLoja>
    {
        public void Configure(EntityTypeBuilder<NomeLoja> builder)
        {
            builder.ToTable("nome_loja");
            builder.HasKey(nl => nl.Id);
            builder.Property(nl => nl.Id).IsRequired().HasMaxLength(100);
        }
    }
}
