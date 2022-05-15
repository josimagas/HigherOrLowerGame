using System;
using System.Threading.Tasks;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Core.Helper;
using HigherOrLowerGame.Api.Core.services;
using Moq;
using Xunit;

namespace HigherOrLowerGame.Tests.Core
{
    public class GameServiceHelperTests
    {
        
        [Theory]
        [InlineData(Guess.Lower, 30, 10, false)] 
        [InlineData(Guess.Lower, 2, 10, true)]
        [InlineData(Guess.Higher, 20, 10, true)] 
        [InlineData(Guess.Higher, 2, 10, false)]
        public async Task CorrectAnswer_ShouldReturnAnAnswer(Guess guess, int generatedValue, int currentCardValue, bool expected)
        {
            //Arrange
            var actual = GameServiceHelper.CorrectAnswer(guess, generatedValue, currentCardValue);
            //Act 

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task GenerateRandomCard_ShouldReturnNumber_BetweenOneToFiftyTwo()
        {
            //Arrange
            //Act 
            var expected = GameServiceHelper.GenerateRandomCard(1, 52);
            //Assert
            Assert.True((expected >0 && expected <=52));
            Assert.IsType<int>(expected);
        }

        [Theory]
        [InlineData("player1", "player1", false, false)]
        [InlineData("player1", "player2", true, false)]
        [InlineData("player1", "player2", false, true)]
        public async Task GameIsValidToPlay_ShouldValidate_GameState(String previousPlayer, String currentPlayer, bool finished, bool expected)
        {

            var result = GameServiceHelper.GameIsValidToPlay(previousPlayer, currentPlayer, finished);
            
            Assert.Equal(result, expected);

        }
    }
}