using System;
using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Entity
{
    public sealed class ProjectContext : IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BlockItem> BlockItems { get; set; }
        public DbSet<Page> Pages { get; set; }


        private IConfigurationRoot configuration;
        
        public ProjectContext()
        {
        }
        
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=ProjectPortal;Trusted_Connection=True;");
    }
}