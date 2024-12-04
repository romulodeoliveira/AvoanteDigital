using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvoanteDigital.Infra.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

            builder.HasKey(u => new { u.Id, u.Email });
            
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Firstname)
                .IsRequired()
                .HasColumnName("Firstname")
                .HasColumnType("varchar(25)");

            builder.Property(u => u.Lastname)
                .IsRequired()
                .HasColumnName("Lastname")
                .HasColumnType("varchar(25)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");
            
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.OwnsOne(u => u.Password, password =>
            {
                password.Property(p => p.Hash)
                    .IsRequired()
                    .HasColumnName("PasswordHash")
                    .HasColumnType("BLOB");

                password.Property(p => p.Salt)
                    .IsRequired()
                    .HasColumnName("PasswordSalt")
                    .HasColumnType("BLOB");
            });

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("int")
                .HasConversion(
                    v => (int)v,
                    v => (UserRole)v);

            builder.Property(u => u.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            
            builder.Property(u => u.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired(true);
    }
}