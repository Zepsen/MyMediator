using Dom.Configurations;
using Dom.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dom
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
