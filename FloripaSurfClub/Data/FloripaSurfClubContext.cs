﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FloripaSurfClub.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace FloripaSurfClub.Data
{
    public class FloripaSurfClubContext : IdentityDbContext<UsuarioSistema, IdentityRole<Guid>, Guid>
    {
        internal FloripaSurfClubContext() { }

        public FloripaSurfClubContext(DbContextOptions<FloripaSurfClubContext> options)
            : base(options)
        {
        }

        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de herança TPT
            modelBuilder.Entity<UsuarioSistema>().ToTable("UsuariosSistema");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Professor>().ToTable("Professores");
            modelBuilder.Entity<Atendente>().ToTable("Atendentes");

            // Configuração das chaves estrangeiras e relacionamentos
            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Aulas)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aula>()
                .HasMany(a => a.Alunos)
                .WithMany(al => al.Aulas)
                .UsingEntity<Dictionary<string, object>>(
                    "AulaAluno",
                    j => j.HasOne<Aluno>().WithMany().HasForeignKey("AlunoId"),
                    j => j.HasOne<Aula>().WithMany().HasForeignKey("AulaId"));

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Equipamento)
                .WithMany()
                .HasForeignKey(a => a.EquipamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Directory.GetCurrentDirectory();
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
