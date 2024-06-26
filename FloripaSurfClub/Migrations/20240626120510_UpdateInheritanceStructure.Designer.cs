﻿// <auto-generated />
using System;
using FloripaSurfClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    [DbContext(typeof(FloripaSurfClubContext))]
    [Migration("20240626120510_UpdateInheritanceStructure")]
    partial class UpdateInheritanceStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FloripaSurfClub.Models.Aluguel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Encerrado")
                        .HasColumnType("boolean");

                    b.Property<Guid>("EquipamentoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("Alugueis");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Aula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Concluida")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("EhPacote")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Caixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataFechamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdUsuarioAbertura")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ValorColaboradores")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorEmpresa")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Equipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValoresAReceber")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Atendente", b =>
                {
                    b.HasBaseType("FloripaSurfClub.Models.Pessoa");

                    b.Property<decimal>("ValorAReceber")
                        .HasColumnType("numeric");

                    b.ToTable("Atendentes", (string)null);
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Cliente", b =>
                {
                    b.HasBaseType("FloripaSurfClub.Models.Pessoa");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorAPagar")
                        .HasColumnType("numeric");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Aluno", b =>
                {
                    b.HasBaseType("FloripaSurfClub.Models.Cliente");

                    b.Property<int>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Peso")
                        .HasColumnType("numeric");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Aluguel", b =>
                {
                    b.HasOne("FloripaSurfClub.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FloripaSurfClub.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Aula", b =>
                {
                    b.HasOne("FloripaSurfClub.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FloripaSurfClub.Models.Professor", "Professor")
                        .WithMany("Aulas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Atendente", b =>
                {
                    b.HasOne("FloripaSurfClub.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("FloripaSurfClub.Models.Atendente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Cliente", b =>
                {
                    b.HasOne("FloripaSurfClub.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("FloripaSurfClub.Models.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Aluno", b =>
                {
                    b.HasOne("FloripaSurfClub.Models.Cliente", null)
                        .WithOne()
                        .HasForeignKey("FloripaSurfClub.Models.Aluno", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FloripaSurfClub.Models.Professor", b =>
                {
                    b.Navigation("Aulas");
                });
#pragma warning restore 612, 618
        }
    }
}