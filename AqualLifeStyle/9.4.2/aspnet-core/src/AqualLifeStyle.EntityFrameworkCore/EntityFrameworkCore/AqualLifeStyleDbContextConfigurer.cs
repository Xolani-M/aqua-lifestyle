using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AqualLifeStyle.EntityFrameworkCore
{
    public static class AqualLifeStyleDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AqualLifeStyleDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AqualLifeStyleDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
