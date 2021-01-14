using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;
using VertPub.Backend.Repos;

namespace VertPub.Backend.Controllers
{

    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class GameLinksController : ControllerBase
    {
        private readonly IGameLinksRepo _repo;
        public GameLinksController(IGameLinksRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameLinksModel>>> GetAllGames()
        {
            var result = await _repo.GetAllGames();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGameById")]
        public async Task<ActionResult<List<GameLinksModel>>> GetGameById(string id)
        {
            var result = await _repo.GetGameById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GameLinksModel>> AddGame([FromBody] GameLinksModel game)
        {
            var result = await _repo.AddGame(game);
            return Ok(result);
        }
    }
}
