using HigherOrLowerGameApi.API.Infra.repositories.interfaces;
using HigherOrLowerGameApi.API.Model;

namespace HigherOrLowerGameApi.API.Infra.repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        
    }
}