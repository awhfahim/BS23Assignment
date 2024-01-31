using BS23Assignment.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BS23Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=.\\SQLEXPRESS;Database=BrainStationProject;User Id=fahim;Password=123456;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegistrationDto>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskDto>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserRegistrationDto> Register {  get; set; }
        public DbSet<TaskDto> Task {  get; set; }
    }
}
