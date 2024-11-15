using AvoanteDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvoanteDigital.Domain.Infra.Data.Mapping;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");
        
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Name)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(100)");
        
        builder.Property(prop => prop.Email)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar(100)");
        
        builder.Property(prop => prop.Email)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar(100)");
        
        builder.Property(prop => prop.TelephoneNumber)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("TelephoneNumber")
            .HasColumnType("varchar(11)");
        
        builder.Property(prop => prop.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
    }
}