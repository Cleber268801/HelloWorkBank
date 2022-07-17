using HelloWorkBank.Model;
using HelloWorkBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloWorkBank.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)


        {
            //Nome Tabela
            builder.ToTable("Cliente");

            //Chave Primaria
            builder.HasKey(x=>x.IdCliente);

            //Identity
            builder.Property(x => x.IdCliente)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVarchar")
                .HasMaxLength(80);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("NVarchar")
                .HasMaxLength(11);

            builder.Property(x => x.NumeroConta)
                .IsRequired()
                .HasColumnName("NumeroConta")
                .HasColumnType("Int")
                .ValueGeneratedOnUpdate();



            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60);


            builder.HasIndex(x => x.NumeroConta)
                .IsUnique();
          

            builder.HasOne(x => x.Conta)
                .WithMany(x=>x.CLientes)
                .HasConstraintName("FK_CLiente_Conta");

            builder.HasOne(x => x.Gerente)
                .WithMany(x=>x.Clientes)
                .HasConstraintName("FK_CLiente_Gerente");
                
          
























        }
    }
}
