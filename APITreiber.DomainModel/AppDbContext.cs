using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using APITreiber.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace APITreiber.DomainModel
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Person> Persons { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }
        
        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((Entity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}