using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eTrade.DataAccess.Concrete.EntityFramework.Context
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {           
            DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
           // dbContextOptionsBuilder.UseNpgsql("User ID=etraderoot@etardedatabase;Password=password;Host=etradedatabase.postgres.database.azure.com;Port=5432;Database=postgres;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
