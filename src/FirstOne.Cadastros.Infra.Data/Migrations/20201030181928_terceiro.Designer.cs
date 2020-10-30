﻿// <auto-generated />
using System;
using FirstOne.Cadastros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstOne.Cadastros.Infra.Data.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20201030181928_terceiro")]
    partial class terceiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirstOne.Cadastros.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf56b7e5-390f-44a4-b44b-9517f7e619ba"),
                            Nome = "teste"
                        });
                });

            modelBuilder.Entity("FirstOne.Cadastros.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc127929-ef16-4287-96ce-c8e2c8a051c2"),
                            Email = "teste@teste.com",
                            PessoaId = new Guid("cf56b7e5-390f-44a4-b44b-9517f7e619ba"),
                            Role = "Gestor",
                            Senha = "teste"
                        });
                });

            modelBuilder.Entity("FirstOne.Cadastros.Domain.Entities.UsuarioClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Endpoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Entidade")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioClaim");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6226d62f-a747-4ba2-a137-1a4e9c44a613"),
                            Endpoint = "Adicionar,Atualizar,Remover,ObterTodos,ObterPorId",
                            Entidade = 0,
                            UsuarioId = new Guid("fc127929-ef16-4287-96ce-c8e2c8a051c2")
                        },
                        new
                        {
                            Id = new Guid("7a1a80af-f3db-4787-b94e-9afd7cd368fe"),
                            Endpoint = "Adicionar,ObterTodos,Claims",
                            Entidade = 1,
                            UsuarioId = new Guid("fc127929-ef16-4287-96ce-c8e2c8a051c2")
                        });
                });

            modelBuilder.Entity("FirstOne.Cadastros.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("FirstOne.Cadastros.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstOne.Cadastros.Domain.Entities.UsuarioClaim", b =>
                {
                    b.HasOne("FirstOne.Cadastros.Domain.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioClaims")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
