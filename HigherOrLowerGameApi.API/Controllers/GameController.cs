using System;
using System.Threading.Tasks;
using HigherOrLowerGameApi.API.Core.Dto;
using HigherOrLowerGameApi.API.Core.services.interfaces;
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
        [HttpPost("StartGame")]
        public async Task<IActionResult> Start()=>Ok(await _service.StartGame());
        
        [HttpPost("{id}/playGame")]
        public async Task<IActionResult> play(Guid id, [FromBody] PlayGameRequest request)=>Ok(await _service.PlayGame(id, request));
        
        [HttpGet("{id}/getGameStatus")]
        public async Task<IActionResult> getStatus(Guid id)=>Ok(await _service.GetGameStatus(id));
    }
}