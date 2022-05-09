using HigherOrLowerGameApi.API.Core;
using HigherOrLowerGameApi.API.Core.interfaces.repositories;
using HigherOrLowerGameApi.API.Model;

namespace HigherOrLowerGameApi.API.DataAcess
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