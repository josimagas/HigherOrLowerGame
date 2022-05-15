using System;
using System.Threading.Tasks;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Core.Helper;

namespace HigherOrLowerGame.Api.Core.services.interfaces
{
    public interface IGameService
    {
        Task<Result<StartGameResponse>> StartGame();

        Task<Result<PlayGameResponse>> PlayGame(Guid id, PlayGameRequest playGameRequest);

        Task<Result<GameStatusResponse>> GetGameStatus(Guid gameId);
    }
}