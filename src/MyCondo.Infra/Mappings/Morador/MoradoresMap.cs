using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCondo.Domain.Entities.Morador;

namespace MyCondo.Infra.Mappings.Morador;

public class MoradoresMap : IEntityTypeConfiguration<Moradores>
{
    public void Configure(EntityTypeBuilder<Moradores> builder)
    {
        builder.ToTable(nameof(Moradores));

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

        builder.HasOne(b => b.Apartamentos)
            .WithMany(a => a.Moradores)
            .HasForeignKey(b => b.ApartamentoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
