using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Core.Helper;
using HigherOrLowerGame.Api.Core.services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigherOrLowerGame.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    public class GamesController : BaseAPIController
    {
        private readonly IGameService _service;
        public GamesController(IGameService service)
        {
            _service = service;
        }
        
        [HttpPost("start")]
        [ProducesResponseType(typeof(Result<StartGameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StartGameResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Start()
        {
            var result = await _service.StartGame();
            return !result.HasError ? (IActionResult)Ok(result):BadRequest(result);
        }

        [HttpPost("{id}/play")]
        [ProducesResponseType(typeof(Result<PlayGameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<PlayGameResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Play([FromRoute]Guid id, [FromBody] PlayGameRequest request)
        {
            var result = await _service.PlayGame(id, request);
            return !result.HasError ? (IActionResult)Ok(result):BadRequest(result);
        }

        [HttpGet("{id}/status")]
        [ProducesResponseType(typeof(Result<GameStatusResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<GameStatusResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatus([FromRoute]Guid id)
        {
            var result = await _service.GetGameStatus(id);
            return !result.HasError ? (IActionResult)Ok(result):BadRequest(result);
        }
    }
}