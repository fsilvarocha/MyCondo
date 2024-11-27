using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCondo.Domain.Entities.Bloco;

namespace MyCondo.Infra.Mappings.Bloco;

public class BlocosMap : IEntityTypeConfiguration<Blocos>
{
    public void Configure(EntityTypeBuilder<Blocos> builder)
    {
        builder.ToTable(nameof(Blocos));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(p => p.QuantidadeAndar)
            .IsRequired()
            .HasDefaultValue(1)
            .HasColumnType("int");

        builder.Property(p => p.DataCriacao)
            .HasDefaultValue(DateTime.Now)
            .HasColumnType("Date");

        builder.Property(p => p.DataAtualizado)
            .HasColumnType("Date");

        builder.HasOne(b => b.Condominios)
            .WithMany(c => c.Blocos)
            .HasForeignKey(b => b.CondominiosId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
