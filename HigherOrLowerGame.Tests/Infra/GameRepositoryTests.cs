using System;
using System.Linq;
using System.Threading.Tasks;
using HigherOrLowerGame.Api.Infra.repositories;
using HigherOrLowerGame.Api.Model;
using Xunit;

namespace HigherOrLowerGame.Tests.Infra
{
    public class GameRepositoryTests
    {
        private readonly GameRepository _gameRepository;
  
        public GameRepositoryTests()
        {
            var dbInMemory = new DbInMemory();
            var context = dbInMemory.GetContext();
            _gameRepository = new GameRepository(context);
        }

        [Fact]

        public async Task GetAll_ShouldReturn_AllGames()
        {
            var games = await _gameRepository.GetAll();
            
            Assert.NotNull(games);
        }
        [Fact]
        public async Task GetById_ShouldReturn_GameWhenGameId_IsPassed()
        {
            var result = await _gameRepository.GetById(Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"));
            
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddAsync_Should_AddGame_WithNoError()
        {
            var result = await _gameRepository.AddAsync(new Game()
            {
                Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                Deleted = false,
                Finished = false,
                CreatedAt = DateTime.Now.ToString(),
                CurrentPlayer = "player1",
                CurrentCardValue = 10,
                FirstPlayerScore = 0,
                SecondPlayerScore = 0,
                NumberOfCardOnDeck = 52
            });
            
            Assert.NotNull(result);
        }
        [Fact]
        public async Task DeleteAsync_Should_Return_WithError()
        {
            var result = await _gameRepository.DeleteAsync(null);
            
            Assert.False(result);
        }
        [Fact]
        public async Task UpdateAsync_Should_Return_ErrorWhenNoGame_IsPassed()
        {
            var result = await _gameRepository.UpdateAsync(null);
            
            Assert.False(result);
        }
   
    }
}