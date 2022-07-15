using HelloWorkBank.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorkBank.Data.Mapping
{
    public class ContaMap : IEntityTypeConfiguration<ContaModel>
    {
        public void Configure(EntityTypeBuilder<ContaModel> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(x => x.IdConta);
            builder.Property(x => x.IdConta)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NomeConta)
                .IsRequired()
                .HasColumnName("NomeConta")
                .HasColumnType("NVarchar")
                .HasMaxLength(100);

            builder.HasIndex(x => x.IdConta)
                .IsUnique();


        }
    }
}
