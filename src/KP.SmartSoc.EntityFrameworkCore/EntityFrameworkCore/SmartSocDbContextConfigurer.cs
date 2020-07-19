using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace KP.SmartSoc.EntityFrameworkCore
{
    public static class SmartSocDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SmartSocDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SmartSocDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
