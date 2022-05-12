using System.ComponentModel.DataAnnotations;
using HigherOrLowerGame.Api.Infra.EntityMap;
using HigherOrLowerGame.Api.Model;
using  Microsoft.EntityFrameworkCore;

namespace HigherOrLowerGame.Api.Infra
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
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.ApplyConfiguration(new GameMap());
        }
        
    }
}