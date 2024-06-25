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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais se necessário
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
