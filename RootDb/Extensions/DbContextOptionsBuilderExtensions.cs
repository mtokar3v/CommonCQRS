using Microsoft.EntityFrameworkCore;

namespace RootDb.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder ApplyDefaultSettings(this DbContextOptionsBuilder builder, string connectionString)
        {
            return builder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }
    }
}
