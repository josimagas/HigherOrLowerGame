namespace HigherOrLowerGameApi.API.Model
{
    public class Game : BaseEntity
    {
        public Game()
        {
            Finished = false;
        }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int NumberOfCardOnDeck { get; set; }
        public int CurrentCardValue { get; set; }
        public string CurrentPlayer {get;set;}
        public bool Finished {get;set;}
    }
}