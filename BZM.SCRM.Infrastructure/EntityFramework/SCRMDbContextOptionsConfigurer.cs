using Microsoft.EntityFrameworkCore;

namespace BZM.SCRM.Infrastructure.EntityFramework
{
   public static class SCRMDbContextOptionsConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SCRMDbContext> dbContextOptions, string connectionString)
        {
            dbContextOptions.UseOracle(connectionString);
        }
    }

}
