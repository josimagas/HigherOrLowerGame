using System;
using HigherOrLowerGame.Api.Core.Dto;

namespace HigherOrLowerGame.Api.Core.Helper
{
    public static class GameServiceHelper
    {

        public static int GenerateRandomCard(int init, int limit)
        {
            Random rnd = new Random();
            int card = rnd.Next(1, 53);
            return (int) card;
        }

        public static bool CorrectAnswer(Guess guess, int generatedValue, int currentCardValue)
        {
            return (guess == Guess.Lower && generatedValue < currentCardValue)
                   || (guess == Guess.Higher && generatedValue > currentCardValue);
        }

        public static bool GameIsValidToPlay(String previousPlayer, String currentPlayer, bool gameIsFinished)
        {
            return !(currentPlayer.ToLower().Equals(previousPlayer)) && !gameIsFinished;
        }
        
    }
}