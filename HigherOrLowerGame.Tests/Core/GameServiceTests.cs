using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HigherOrLowerGame.Api.Core.services;
using HigherOrLowerGame.Api.Infra.repositories.interfaces;
using HigherOrLowerGame.Api.Model;
using Moq;
using Xunit;

namespace HigherOrLowerGame.Tests
{
public class GameServiceTests
{
    private readonly GameService _sut;
    private  readonly Mock<IGameRepository> _gameRepoMock  = new Mock<IGameRepository>();
    private  readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
    
    public GameServiceTests()
    {
        _sut = new GameService(_gameRepoMock.Object, _mapperMock.Object);
    }

    #region StartGameTests


    #endregion 
    
    #region PlayGameTests


    #endregion
    
    #region GetGameStatus
    [Fact]
    public async Task GetGameStatus_ShouldReturnGameStatus_WhenGameExists()
    {

        //Arrange
        var gameId = Guid.NewGuid();
        var game = new Game
        {
            Id = gameId,
            CurrentPlayer = "player1",
            Deleted = false,
            Finished = false,
            CreatedAt = DateTime.Now.ToString(),
            CurrentCardValue = 1,
            FirstPlayerScore = 0,
            SecondPlayerScore = 0,
            NumberOfCardOnDeck = 52
        };
        _gameRepoMock.Setup(x => x.GetById(gameId)).ReturnsAsync(game);

        //Act 
        var gameStatus = _sut.GetGameStatus(gameId);

        //Assert
        Assert.True(gameStatus.Result.HasSuccess);
        Assert.Equal((HttpStatusCode) 200, gameStatus.Result.HttpStatusCode);
    }
    [Fact]
    public async Task GetGameStatus_ShouldReturnError_WhenGameDoesNotExists()
    {

        //Arrange
        _gameRepoMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(()=>null);

        //Act 
        var gameStatus = _sut.GetGameStatus(Guid.NewGuid());

        //Assert
        
        Assert.False(gameStatus.Result.HasSuccess);
        Assert.Equal((HttpStatusCode) 404, gameStatus.Result.HttpStatusCode);
      
    }
    [Fact]
    public async Task GetGameStatus_ShouldReturnError_WhenGameIdParameterIsNull()
    {
        //Arrange 
        Guid gameId = Guid.Empty;
        //Act 
        var gameStatus = _sut.GetGameStatus(gameId);

        //Assert
        
        Assert.False(gameStatus.Result.HasSuccess);
        Assert.Equal((HttpStatusCode) 400, gameStatus.Result.HttpStatusCode);
    }

    #endregion
   

}
}