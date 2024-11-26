﻿// <auto-generated />
using System;
using AvoanteDigital.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AvoanteDigital.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241124175502_Migration_0002")]
    partial class Migration_0002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AvoanteDigital.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("TelephoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("AvoanteDigital.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Lastname");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("Role");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(4000)")
                        .HasColumnName("Token");

                    b.HasKey("Id", "Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AvoanteDigital.Domain.Entities.User", b =>
                {
                    b.OwnsOne("AvoanteDigital.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("UserEmail")
                                .HasColumnType("varchar(50)");

                            b1.Property<byte[]>("Hash")
                                .IsRequired()
                                .HasColumnType("BLOB")
                                .HasColumnName("PasswordHash");

                            b1.Property<byte[]>("Salt")
                                .IsRequired()
                                .HasColumnType("BLOB")
                                .HasColumnName("PasswordSalt");

                            b1.HasKey("UserId", "UserEmail");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId", "UserEmail");
                        });

                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
