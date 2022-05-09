using System.ComponentModel.DataAnnotations;
using HigherOrLowerGameApi.API.Core.EntityMap;
using HigherOrLowerGameApi.API.Model;
using  Microsoft.EntityFrameworkCore;

namespace HigherOrLowerGameApi.API.Core
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