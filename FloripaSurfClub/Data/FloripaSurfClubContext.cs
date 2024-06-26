using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            modelBuilder.Entity<UsuarioSistema>().ToTable("UsuariosSistema");

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.UsuarioSistema)
                .WithMany()
                .HasForeignKey(p => p.UsuarioSistemaId);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.UsuarioSistema)
                .WithMany()
                .HasForeignKey(a => a.UsuarioSistemaId);

            modelBuilder.Entity<Atendente>()
                .HasOne(a => a.UsuarioSistema)
                .WithMany()
                .HasForeignKey(a => a.UsuarioSistemaId);

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Aulas)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Aluno)
                .WithMany()
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

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
