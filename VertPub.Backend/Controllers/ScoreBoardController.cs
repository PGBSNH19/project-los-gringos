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
            return Ok(await _repo.GetScoreboardByGameId(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<ScoreBoardModel>>> ChangeScoreBoard([FromBody] ScoreBoardModel scoreBoard) 
        {
            var result = await _repo.CreateScoreBoard(scoreBoard);
            return Ok(result);
        }

      


    }
}
