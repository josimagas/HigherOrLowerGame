
using System;
using System.Threading.Tasks;
using AutoMapper;
using HigherOrLowerGameApi.API.Core.Dto;
using HigherOrLowerGameApi.API.Core.services.interfaces;
using HigherOrLowerGameApi.API.Infra.repositories.interfaces;
using HigherOrLowerGameApi.API.Model;

namespace HigherOrLowerGameApi.API.Core.services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<StarGameResponse>> StartGame()
        {
            var result = new Result<StarGameResponse>();
            var randomValue = GameHelper.GenerateRandomCard(1, 52);
            
            var game = await _repository.AddAsync(new Game()
            {
                FirstPlayerScore = 0,
                SecondPlayerScore = 0,
                NumberOfCardOnDeck = 52,
                CurrentPlayer = string.Empty,
                CurrentCardValue = randomValue
            });
            
            result.Value = _mapper.Map<StarGameResponse>(game);
            return result;
        }

        public async Task<Result<PlayGameResponse>> PlayGame(Guid id,  PlayGameRequest playGameRequest)
        {
            var result = new Result<PlayGameResponse>();
            var randomValue = GameHelper.GenerateRandomCard(1, 52);
            
            var game = await _repository.GetById(id);
            
            if (game.CurrentPlayer.ToLower().Equals(playGameRequest.CurrentPlayer))
            {
                
                result.WithError("This is not your turn to play");
                return result;
            }

            if (game.Finished)
            {
                result.WithError("This game is over. Please, start another game");
                return result;
            }
            
            var answerCorrect = GameHelper.CorrectAnswer(playGameRequest.Guess, randomValue, game.CurrentCardValue);

            game.CurrentCardValue = randomValue;
            game.CurrentPlayer = playGameRequest.CurrentPlayer;
            game.NumberOfCardOnDeck = game.NumberOfCardOnDeck - 1;
            game.Finished = game.NumberOfCardOnDeck == 0 ? true : false;
            game.FirstPlayerScore = answerCorrect && playGameRequest.CurrentPlayer == "player1" ? game.FirstPlayerScore+1 : game.FirstPlayerScore;
            game.SecondPlayerScore = answerCorrect && playGameRequest.CurrentPlayer == "player2" ? game.SecondPlayerScore+1 : game.SecondPlayerScore;

            if (!await _repository.UpdateAsync(game))
            {
                result.WithException("Something bad happened.");
                return result;
            };
            
            result.Value =  _mapper.Map<PlayGameResponse>(game);
            result.Value.CorrectAnswer = answerCorrect;
            return result;
        }

        public async Task<Result<GameStatusResponse>> GetGameStatus(Guid gameId)
        {
            var result = new Result<GameStatusResponse>();
            if (String.IsNullOrWhiteSpace(gameId.ToString()))
            {
               result.WithError("Game Id must not be null");
               return result;
            }
            
            var game = await _repository.GetById(gameId);

            if (game == null)
            {
                result.WithNotFound("Game does not exist");
                return result;
            }
            
            result.Value = _mapper.Map<GameStatusResponse>(game);
           return result;
        }
    }
}