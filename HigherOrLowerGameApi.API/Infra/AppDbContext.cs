using System.ComponentModel.DataAnnotations;
using HigherOrLowerGameApi.API.Infra.EntityMap;
using HigherOrLowerGameApi.API.Model;
using  Microsoft.EntityFrameworkCore;

namespace HigherOrLowerGameApi.API.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Game> Game { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfiguration(new GameMap());
        }
        
    }
}