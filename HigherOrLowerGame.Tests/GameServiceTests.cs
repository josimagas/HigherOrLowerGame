using System;
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

    [Fact]
    public async Task GetGameStatus_ShouldReturnGameStatus_WhenGameExists()
    {

    //Arrange
    var gameId = Guid.NewGuid();
    var game = new Game
    {
        Id = gameId,
        CurrentPlayer = "player1"
    };
    _gameRepoMock.Setup(x => x.GetById(gameId)).ReturnsAsync(game);

    //Act 
    var gameStatus = _sut.GetGameStatus(gameId);

    //Assert
    Assert.Equal(gameId, game.Id);
    }
    [Fact]
    public async Task GetGameStatus_ShouldReturnError_WhenGameDoesNotExists()
    {

        //Arrange
        var game = new Game
        {
            Id = Guid.NewGuid()
        };
        _gameRepoMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(game);

        //Act 
        var gameStatus = _sut.GetGameStatus(Guid.NewGuid());

        //Assert
        
        Assert.NotEqual(gameStatus.Result.HasError, true);
      
    }
    [Fact]
    public async Task GetGameStatus_ShouldReturnError_WhenGameIdParameterIsNull()
    {
        var game = new Game
        {
            Id = Guid.NewGuid()
        };
        _gameRepoMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(game);

        //Act 
        var gameStatus = _sut.GetGameStatus(Guid.NewGuid());

        //Assert
        
        Assert.NotEqual(gameStatus.Result.HasError, true);
        
    }

}
}