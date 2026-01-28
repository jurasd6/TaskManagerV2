using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManagerV2.Infrastructure.Persistence
{
    public class AppDbContextFactory
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=taskmanagerdb;user=user;password=password;",
                new MySqlServerVersion(new Version(8, 0, 39))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
