using System;

namespace HigherOrLowerGameApi.API.Core.Dto
{
    public class GameStatusResponse
    {
        public Guid Id { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int NumberOfCardOnDeck { get; set; }
        public int CurrentCardValue { get; set; }
        public bool Finished {get;set;}
        
    }
}