using System;
using System.Threading.Tasks;
using HigherOrLowerGameApi.API.Core.Dto;
using HigherOrLowerGameApi.API.Core.Helper;
using HigherOrLowerGameApi.API.Core.services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigherOrLowerGameApi.API.Controllers
{
    public class GameController : BaseAPIController
    {
        private readonly IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }
        
        [HttpPost("start")]
        [ProducesResponseType(typeof(Result<StarGameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StarGameResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Start()=>Ok(await _service.StartGame());
        
        [HttpPost("{id}/play")]
        [ProducesResponseType(typeof(Result<PlayGameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<PlayGameResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> play(Guid id, [FromBody] PlayGameRequest request)=>Ok(await _service.PlayGame(id, request));
        
        [HttpGet("{id}/status")]
        [ProducesResponseType(typeof(Result<GameStatusResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<GameStatusResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getStatus(Guid id)=>Ok(await _service.GetGameStatus(id));
    }
}