using HigherOrLowerGameApi.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HigherOrLowerGameApi.API.Core.EntityMap
{
    public class GameMap: IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Game));
            
            entityTypeBuilder.Property(e => e.Id).ValueGeneratedNever();            

        }

    }
}