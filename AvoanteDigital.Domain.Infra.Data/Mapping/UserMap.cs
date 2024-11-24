using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvoanteDigital.Domain.Infra.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

            // Definindo a chave primária
            builder.HasKey(u => new { u.Id, u.Email });
            
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // Definindo a propriedade 'Firstname' como obrigatória, com um nome de coluna personalizado e tipo 'varchar(100)'
            builder.Property(u => u.Firstname)
                .IsRequired()
                .HasColumnName("Firstname")
                .HasColumnType("varchar(25)");

            // Definindo a propriedade 'Lastname' como obrigatória, com um nome de coluna personalizado e tipo 'varchar(100)'
            builder.Property(u => u.Lastname)
                .IsRequired()
                .HasColumnName("Lastname")
                .HasColumnType("varchar(25)");

            // Configurando a propriedade 'Email' como obrigatória, com um nome de coluna personalizado e tipo 'varchar(100)'
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");
            
            builder.HasIndex(u => u.Email)
                .IsUnique();

            // Mapeando a propriedade 'Password' como um Owned Type
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

            // Configurando a propriedade 'Role', convertendo o valor do enum para inteiro no banco de dados
            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("int")
                .HasConversion(
                    v => (int)v,   // Convertendo o enum para inteiro ao armazenar no banco
                    v => (UserRole)v);  // Convertendo de inteiro para enum ao ler do banco

            // Configurando a propriedade 'CreatedAt', com valor padrão e tipo 'datetime'
            builder.Property(u => u.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
    }
}