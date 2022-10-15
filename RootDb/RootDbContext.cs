using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RootDb.Configurations;
using RootDb.Entities;
using RootDb.Extensions;

namespace RootDb
{
    public class RootDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public RootDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured) return;

            var configurations = GetConfigurations();
            builder.ApplyDefaultSettings(configurations.GetConnectionString());
        }

        private RootDbConfigurations GetConfigurations()
        {
            var developmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Environment.UserDomainName, "Config");

            var builder = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("dbsettings.json")
                    .AddJsonFile($"dbsettings.{developmentName}.json", optional: true)
                    .Build();

            return builder
                    .GetSection("RootDbConfig")
                    .Get<RootDbConfigurations>();
        }
    }
}
