using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
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
            base.OnModelCreating(modelBuilder);
        }

    }
}
