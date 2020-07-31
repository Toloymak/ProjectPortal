using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public sealed class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        public ProjectContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=ProjectPortal;Trusted_Connection=True;");
    }
}