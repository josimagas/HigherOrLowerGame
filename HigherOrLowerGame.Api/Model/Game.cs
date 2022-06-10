using HigherOrLowerGame.Api.Core.Dto;

namespace HigherOrLowerGame.Api.Model
{
    public class Game : BaseEntity
    {
        public Game() {
            Finished = false;
            NumberOfCardOnDeck = 52;
        }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int NumberOfCardOnDeck { get; set; }
        public int CurrentCardValue { get; set; }
        public string CurrentPlayer {get;set;}
        public bool Finished {get;set;}


        public bool IsGameValid(String newPlayer)
        {

            return (!Finished && NumberOfCardOnDeck>0) 
                     && (!this.CurrentPlayer.ToLower().Equals(newPlayer.ToLower()));
        }

          public  bool isAnswerCorrect(Guess guess, int previousCard)
        {
            return (guess == Guess.Lower && CurrentCardValue < previousCard)
                   || (guess == Guess.Higher && CurrentCardValue > previousCard);
        }
        public void setGameStatus(string player, bool answerCorrect)
        {
            FirstPlayerScore = answerCorrect && player == "player1" ? FirstPlayerScore+1 : FirstPlayerScore;
            SecondPlayerScore = answerCorrect && player == "player2" ? SecondPlayerScore+1 : SecondPlayerScore;
            CurrentPlayer = player;            
            Finished = NumberOfCardOnDeck == 0 ? true : false;

            
        }
         public void  ShuffleCard()
        {
            Random rnd = new Random();
            int card = rnd.Next(1, this.NumberOfCardOnDeck);
            
            if (this.CurrentCardValue == card)
            {
                ShuffleCard();
            }
            else
            {
                this.NumberOfCardOnDeck = this.NumberOfCardOnDeck - 1;
                this.CurrentCardValue = card;
            }
        }

    }
}