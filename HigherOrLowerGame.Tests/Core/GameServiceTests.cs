using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Core.Helper;
using HigherOrLowerGame.Api.Core.services;
using HigherOrLowerGame.Api.Infra.repositories.interfaces;
using HigherOrLowerGame.Api.Model;
using Moq;
using Xunit;

namespace HigherOrLowerGame.Tests.Core
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

    [Fact]
    public async Task StartGame_ShouldCreateNewGame()
    {
        // Arrage
        var random = GameServiceHelper.GenerateRandomCard(1, 52);
        _gameRepoMock.Setup(x => x.AddAsync(new Game()
        {
            CurrentCardValue = random
        })).ReturnsAsync(new Game());
        
        _mapperMock.Setup(m => m.Map<Game, StartGameResponse>(It.IsAny<Game>())).Returns(new StartGameResponse()
        {
            Id = Guid.NewGuid(),
            CurrentCardValue = random,
            NumberOfCardOnDeck = 52
        });
        
        // Act
        var game = _sut.StartGame();
        // Assert
        Assert.True(game.Result.HasSuccess);
    }


    #endregion 
    
    #region PlayGameTests

    [Fact]
    public async Task PlayGame_ShouldReturnError_WhenGameIsFinished()
    {
        
        // Arrange 
        var randomValue = GameServiceHelper.GenerateRandomCard(1, 52);
        var move = new PlayGameRequest {Guess = It.IsAny<Guess>(), CurrentPlayer = "player1"};
        var game = new Game()
        {
            Id = Guid.NewGuid(),
            CurrentPlayer = "player2",
            Finished = true,
            CurrentCardValue = randomValue
        };
        _gameRepoMock.Setup(x => x.GetById(game.Id)).ReturnsAsync(game);
        
        // Act 
        var result = _sut.PlayGame(game.Id, move);
        // Assert
        Assert.True(result.Result.HasError);

    }
    [Fact]
    public async Task PlayGame_ShouldReturnError_WhenGamePlayerAreEqual()
    {
        
        // Arrange 
        var randomValue = GameServiceHelper.GenerateRandomCard(1, 52);
        var move = new PlayGameRequest {Guess = It.IsAny<Guess>(), CurrentPlayer = "player1"};
        var game = new Game()
        {
            Id = Guid.NewGuid(),
            CurrentPlayer = "player1",
            Finished = false,
            CurrentCardValue = randomValue
        };
        _gameRepoMock.Setup(x => x.GetById(game.Id)).ReturnsAsync(game);
        
        // Act 
        var result = _sut.PlayGame(game.Id, move);
        // Assert
        Assert.True(result.Result.HasError);

    }
    [Fact]
    public async Task PlayGame_ShouldUpdateGame_WhenValid()
    {
        // Arrange 
        var randomValue = GameServiceHelper.GenerateRandomCard(1, 52);
        var move = new PlayGameRequest {Guess = It.IsAny<Guess>(), CurrentPlayer = "player1"};
        var game = new Game()
        {
            Id = Guid.NewGuid(),
            CurrentPlayer = "player2",
            Finished = true,
            CurrentCardValue = 10
        };
        _gameRepoMock.Setup(x => x.GetById(game.Id)).ReturnsAsync(new Game());
        
        
        _gameRepoMock.Setup(x => x.UpdateAsync(It.IsAny<Game>())).ReturnsAsync(()=>true);

        
        var answerCorrect = GameServiceHelper.CorrectAnswer(move.Guess, randomValue , game.CurrentCardValue);
        
        // Act 
        var result = _sut.PlayGame(game.Id, move);
        
        _mapperMock.Setup(m => m.Map<Game, PlayGameResponse>(It.IsAny<Game>())).Returns(new PlayGameResponse()
        {
            Id = game.Id,
            CorrectAnswer = answerCorrect,
            CurrentCardValue = randomValue});
        // Assert
        Assert.True(result.Result.HasSuccess);

    }

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
        
        _mapperMock.Setup(m => m.Map<Game, GameStatusResponse>(It.IsAny<Game>())).Returns(new GameStatusResponse()
        {
            Finished = game.Finished,
            Id = game.Id,
            CurrentCardValue = game.CurrentCardValue,
            FirstPlayerScore = game.FirstPlayerScore,
            SecondPlayerScore = game.SecondPlayerScore,
            NumberOfCardOnDeck = game.NumberOfCardOnDeck
        });

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