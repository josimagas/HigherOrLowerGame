using System;

namespace HigherOrLowerGame.Api.Core.Dto
{
    public class StarGameResponse
    {
        public Guid Id { get; set; }
        public int NumberOfCardOnDeck { get; set; }
        public int CurrentCardValue { get; set; }
    }
}