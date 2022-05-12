using HigherOrLowerGame.Api.Core.Dto;

namespace HigherOrLowerGame.Api.Core.Helper
{
    public static class GameHelper
    {

        public static int GenerateRandomCard(int init, int limit)
        {
            return 10;
        }

        public static bool CorrectAnswer(Guess guess, int generatedValue, int currentCardValue)
        {
            return (guess == Guess.Lower && generatedValue < currentCardValue)
                   || (guess == Guess.Higher && generatedValue > currentCardValue);
        }
        
    }
}