using System;

namespace HigherOrLowerGame.Api.Core.Dto
{
    public class PlayGameRequest
    {
        public string CurrentPlayer {get;set;}
        public Guess Guess { get; set; }
    }
}