using System;
using System.Threading.Tasks;
using HigherOrLowerGameApi.API.Core.Dto;

namespace HigherOrLowerGameApi.API.Core.services.interfaces
{
    public interface IGameService
    {
        Task<Result<StarGameResponse>> StartGame();

        Task<Result<PlayGameResponse>> PlayGame(Guid id, PlayGameRequest playGameRequest);

        Task<Result<GameStatusResponse>> GetGameStatus(Guid gameId);
    }
}