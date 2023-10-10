using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Entities;

namespace TimeSheet.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
     }
}
