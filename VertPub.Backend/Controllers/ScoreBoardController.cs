using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _repo.GetAllScorbords();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ScoreBoardModel>>> GetScorboardsByGameId(Guid id)
        {
            return await _repo.GetScoreboardByGameId(id);

        }

        [HttpPut]
        public async Task<ActionResult<List<ScoreBoardModel>>> ChangeScoreBoard(string name, int points,Guid id) 
        {
            var result = await _repo.ChangeScoreboard(name,points,id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateScoreBoard([FromBody]ScoreBoardModel scoreBoard) 
        {
            var result = await _repo.CreateScoreBoard(scoreBoard);
            return Ok(result);
        }


    }
}
