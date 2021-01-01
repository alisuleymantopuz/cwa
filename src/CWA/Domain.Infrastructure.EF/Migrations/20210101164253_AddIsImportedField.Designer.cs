﻿// <auto-generated />
using System;
using Domain.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Infrastructure.EF.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210101164253_AddIsImportedField")]
    partial class AddIsImportedField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsImported")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(60);

                    b.Property<DateTime>("ProductRegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f457923e-6b73-4711-887a-093dc0a1e34e"),
                            IsImported = false,
                            Name = "IPhone X",
                            ProductRegisterDate = new DateTime(2021, 1, 1, 16, 42, 50, 936, DateTimeKind.Utc).AddTicks(7106),
                            UnitPrice = 1000m
                        });
                });

            modelBuilder.Entity("Domain.ProductsTags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductsTags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87447a4a-a125-4913-9670-d0e8963a9af6"),
                            ProductId = new Guid("f457923e-6b73-4711-887a-093dc0a1e34e"),
                            TagId = new Guid("c609571b-086d-4343-838b-6d4147920afe")
                        });
                });

            modelBuilder.Entity("Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c609571b-086d-4343-838b-6d4147920afe"),
                            Name = "Mobile phone"
                        });
                });

            modelBuilder.Entity("Domain.ProductsTags", b =>
                {
                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductsTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Tag", "Tag")
                        .WithMany("ProductsTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
