using AvoanteDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvoanteDigital.Infra.Mapping;

public class EbookMap : IEntityTypeConfiguration<Ebook>
{
    public void Configure(EntityTypeBuilder<Ebook> builder)
    {
        builder.ToTable("Ebooks");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(100);

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.PDF)
            .IsRequired()
            .HasColumnType("LONGBLOB");

        builder.Property(e => e.CreatedAt)
            .IsRequired();
    }
}