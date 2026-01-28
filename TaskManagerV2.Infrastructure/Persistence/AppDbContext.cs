using Microsoft.EntityFrameworkCore;
using TaskManagerV2.Core.Entities;

namespace TaskManagerV2.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskItem>().ToTable("Tasks");
        }
    }
}
