using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace vcoresrobotics.website.EntityFrameworkCore
{
    public static class websiteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<websiteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<websiteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
