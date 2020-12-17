﻿using Microsoft.AspNetCore.Mvc;
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
            var resault = await _repo.GetAllGames();
            return Ok(resault);
        }
        [HttpPost]
        public async Task<ActionResult<GameLinksModel>> AddGame([FromBody] GameLinksModel game)
        {
            var result = await _repo.AddGame(game);
            return Ok(result);
        }
    }
}
