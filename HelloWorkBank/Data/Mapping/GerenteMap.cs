using HelloWorkBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorkBank.Data.Mapping
{
    public class GerenteMap : IEntityTypeConfiguration<GerenteModel>
    {
        public void Configure(EntityTypeBuilder<GerenteModel> builder)
        {
            builder.ToTable("Gerente");

            builder.HasKey(x => x.IdGerente);
            builder.Property(x => x.IdGerente)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NomeGerente)
                .IsRequired()
                .HasColumnName("NomeGerente")
                .HasColumnType("NVarchar")
                .HasMaxLength(100);

           builder.HasIndex(x => x.NomeGerente)
                .IsUnique();

        }
    }
}
