using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Entities;
using BCrypt.Net;

namespace TimeSheet.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Emplyee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Client>().HasOne(c => c.Country)
                    .WithMany()
                    .HasForeignKey(c => c.CountryId);          

            modelBuilder.Entity<Project>().HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            
            modelBuilder.Entity<Project>().HasOne(p => p.Leader)
                .WithMany()
                .HasForeignKey(p => p.LeaderId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<WorkingHour>().HasOne(wh => wh.Project)
                .WithMany()
                .HasForeignKey(wh => wh.ProjectId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WorkingHour>()
            .HasOne(wh => wh.Emplyee)
            .WithMany()
            .HasForeignKey(wh => wh.EmplyeeId)
            .OnDelete(DeleteBehavior.Restrict);



        }
    }
}