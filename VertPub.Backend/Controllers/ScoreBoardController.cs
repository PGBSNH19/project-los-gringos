using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;
using VertPub.Backend.Repos;

namespace VertPub.Backend.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ScoreBoardController : ControllerBase
    {
        private readonly IScoreBoardRepo _repo;
        public ScoreBoardController(IScoreBoardRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ScoreBoardModel>>> GetAllScoreBoards()
        {
            var result = await _repo.GetAllScoreboards();
            return Ok(result);
        }

        [HttpGet("{sportId}")]
        public async Task<ActionResult<List<ScoreBoardModel>>> GetScoreboardsByGameId(Guid sportId)
        {
            return Ok(await _repo.GetScoreboardByGameId(sportId));
        }

        [HttpPost]
        public async Task<ActionResult<List<ScoreBoardModel>>> ChangeScoreBoard([FromBody] ScoreBoardModel scoreBoard)
        {
            var result = await _repo.CreateScoreBoard(scoreBoard);
            return Ok(result);
        }
    }
}
