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

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(p => p.DataCriacao)
            .HasDefaultValue(DateTime.Now)
            .HasColumnType("Date");

        builder.Property(p => p.DataAtualizado)
            .HasColumnType("Date");
    }
}
