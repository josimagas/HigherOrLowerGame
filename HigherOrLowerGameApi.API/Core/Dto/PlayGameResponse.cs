using System;

namespace HigherOrLowerGameApi.API.Core.Dto
{
    public class PlayGameResponse
    {
        public bool CorrectAnswer { get; set; }
        public Guid GameId { get; set; }
        public int  CurrentCardValue { get; set; }
        public int FirstPlayerScore { get; set; }
        public int  SecondPlayerScore { get; set; }
        public int  NumberOfCardOnDeck { get; set; }
        
    }
}