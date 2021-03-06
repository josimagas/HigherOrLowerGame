using System.Diagnostics.CodeAnalysis;
using HigherOrLowerGame.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HigherOrLowerGame.Api.Infra.EntityMap
{
    [ExcludeFromCodeCoverage]
    public class GameMap: IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Game));
            
            entityTypeBuilder.Property(e => e.Id).ValueGeneratedNever();
            entityTypeBuilder.Property(e => e.CurrentPlayer).HasMaxLength(50);

        }

    }
}