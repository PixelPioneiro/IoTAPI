﻿// <auto-generated />
using System;
using IoTAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IoTAPI.Migrations
{
    [DbContext(typeof(IoTAPIDbContext))]
    [Migration("20241001022858_Correcao2")]
    partial class Correcao2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IoTAPI.Models.CatSub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubCategoriaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("CatSub");
                });

            modelBuilder.Entity("IoTAPI.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("IoTAPI.Models.Estoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataOut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("QuantidadeIn")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("QuantidadeOut")
                        .HasColumnType("decimal(7,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("UserId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("IoTAPI.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<Guid>("CatSubId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CatSubId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("IoTAPI.Models.SubCategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("SubCategoria");
                });

            modelBuilder.Entity("IoTAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ativo")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IoTAPI.Models.CatSub", b =>
                {
                    b.HasOne("IoTAPI.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IoTAPI.Models.SubCategoria", "SubCategoria")
                        .WithMany()
                        .HasForeignKey("SubCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("SubCategoria");
                });

            modelBuilder.Entity("IoTAPI.Models.Estoque", b =>
                {
                    b.HasOne("IoTAPI.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IoTAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IoTAPI.Models.Produto", b =>
                {
                    b.HasOne("IoTAPI.Models.CatSub", "CatSub")
                        .WithMany()
                        .HasForeignKey("CatSubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatSub");
                });

            modelBuilder.Entity("IoTAPI.Models.SubCategoria", b =>
                {
                    b.HasOne("IoTAPI.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
