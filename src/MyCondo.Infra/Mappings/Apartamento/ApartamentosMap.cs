using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Infra.Mappings.Apartamento;

public class ApartamentosMap : IEntityTypeConfiguration<Apartamentos>
{
    public void Configure(EntityTypeBuilder<Apartamentos> builder)
    {
        builder.ToTable(nameof(Apartamentos));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Numero)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Andar)
            .IsRequired()
            .HasDefaultValue(1)
            .HasColumnType("int");

        builder.Property(p => p.TipoApartamento)
            .IsRequired()
            .HasDefaultValue(ETipoApartamento.Comun)
            .HasColumnType("int");

        builder.Property(p => p.DataCriacao)
            .HasDefaultValue(DateTime.Now)
            .HasColumnType("Date");

        builder.Property(p => p.DataAtualizado)
            .HasColumnType("Date");

        builder.HasOne(b => b.Blocos)
            .WithMany(a => a.Apartamentos)
            .HasForeignKey(b => b.BlocosId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
