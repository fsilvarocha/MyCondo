using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCondo.Domain.Entities.Condominio;

namespace MyCondo.Infra.Mappings.Condominio;

public class CondominiosMap : IEntityTypeConfiguration<Condominios>
{
    public void Configure(EntityTypeBuilder<Condominios> builder)
    {
        builder.ToTable(nameof(Condominios));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(p => p.DataCriacao)
            .HasDefaultValue(DateTime.Now)
            .HasColumnType("Date");

        builder.Property(p => p.DataAtualizado)
            .HasColumnType("Date");

        builder.Property(p => p.Cnpj)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.TipoCondominio)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Logo)
            .HasColumnType("varchar(500)");

        builder.Property(p => p.AreaTotal)
            .HasColumnType("double(18,5)");

        builder.Property(p => p.Cep)
            .IsRequired()
            .HasColumnType("varchar(10)");

        builder.Property(p => p.Cidade)
            .HasColumnType("varchar(150)");

        builder.Property(p => p.Uf)
            .HasColumnType("varchar(2)");

        builder.Property(p => p.Bairro)
            .HasColumnType("varchar(150)");

        builder.Property(p => p.Logradouro)
            .HasColumnType("varchar(150)");

        builder.Property(p => p.Numero)
            .HasColumnType("varchar(15)");

        builder.Property(p => p.Complemento)
            .HasColumnType("varchar(100)");

        builder.Navigation(p => p.Blocos)
            .AutoInclude();
    }
}
