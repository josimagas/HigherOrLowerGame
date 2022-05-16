
using System;
using System.Threading.Tasks;
using AutoMapper;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Core.Helper;
using HigherOrLowerGame.Api.Core.services.interfaces;
using HigherOrLowerGame.Api.Infra.repositories.interfaces;
using HigherOrLowerGame.Api.Model;

namespace HigherOrLowerGame.Api.Core.services
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
        public async Task<Result<StartGameResponse>> StartGame()
        {
            var result = new Result<StartGameResponse>();
            var randomValue = GameServiceHelper.GenerateRandomCard(1, 52);
            
            var game = await _repository.AddAsync(new Game()
            {
                FirstPlayerScore = 0,
                SecondPlayerScore = 0,
                NumberOfCardOnDeck = 52,
                CurrentPlayer = string.Empty,
                Finished = false,
                CurrentCardValue = randomValue
            });
            
            result.Value = _mapper.Map<StartGameResponse>(game);
            return result;
        }

        public async Task<Result<PlayGameResponse>> PlayGame(Guid id,  PlayGameRequest playGameRequest)
        {
            var result = new Result<PlayGameResponse>();
            var randomValue = GameServiceHelper.GenerateRandomCard(1, 52);
            
            var game = await _repository.GetById(id);
            if (game is null)
            {
                result.WithNotFound("Game does not exist");
                return result;
            }

            if (!GameServiceHelper.GameIsValidToPlay(game.CurrentPlayer, playGameRequest.CurrentPlayer, game.Finished))
            {
                result.WithError(game.Finished ? "This game is over." : "This is not your turn to play");
                return result;
            }

            var answerCorrect = GameServiceHelper.CorrectAnswer(playGameRequest.Guess, randomValue, game.CurrentCardValue);

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
            result.Value = _mapper.Map<PlayGameResponse>(game);;
            return result;
        }

        public async Task<Result<GameStatusResponse>> GetGameStatus(Guid gameId)
        {
            var result = new Result<GameStatusResponse>();
            if (gameId == Guid.Empty)
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