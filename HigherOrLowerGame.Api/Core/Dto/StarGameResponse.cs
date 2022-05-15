using System;

namespace HigherOrLowerGame.Api.Core.Dto
{
    public class StartGameResponse
    {
        public Guid Id { get; set; }
        public int NumberOfCardOnDeck { get; set; }
        public int CurrentCardValue { get; set; }
    }
}