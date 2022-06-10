
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
            var game = new Game();
            game.ShuffleCard();          
            
            result.Value = _mapper.Map<StartGameResponse>(await _repository.AddAsync(game));
            return result;
        }

        public async Task<Result<PlayGameResponse>> PlayGame(Guid id,  PlayGameRequest playGameRequest)
        {
            var result = new Result<PlayGameResponse>();           
            
            Game game = await _repository.GetById(id);
                        
            if (game is null)
            {
                result.WithNotFound("Game does not exist");
                return result;
            }

            if (!game.IsGameValid(playGameRequest.CurrentPlayer))
            {
                result.WithError(game.Finished ? "This game is over." : "This is not your turn to play");
                return result;
            }
            var previousCard = game.CurrentCardValue;

            game.ShuffleCard();

            var answerCorrect = game.isAnswerCorrect(playGameRequest.Guess, previousCard);

            game.setGameStatus(playGameRequest.CurrentPlayer, answerCorrect);            
            
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