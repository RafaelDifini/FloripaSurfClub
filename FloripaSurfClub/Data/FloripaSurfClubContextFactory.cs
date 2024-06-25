using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FloripaSurfClub.Data
{
    public class FloripaSurfClubContextFactory : IDesignTimeDbContextFactory<FloripaSurfClubContext>
    {
        public FloripaSurfClubContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FloripaSurfClubContext>();

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../FloripaSurfClubAPI");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new FloripaSurfClubContext(optionsBuilder.Options);
        }
    }
}
