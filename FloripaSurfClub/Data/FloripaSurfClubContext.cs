using Microsoft.EntityFrameworkCore;
using FloripaSurfClub.Models;
using Microsoft.Extensions.Configuration;

namespace FloripaSurfClub.Data
{
    public class FloripaSurfClubContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().ToTable("Pessoas");
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Atendente>().ToTable("Atendentes");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");


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
