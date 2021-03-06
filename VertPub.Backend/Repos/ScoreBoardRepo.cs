﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertPub.Backend.Context;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public class ScoreBoardRepo : IScoreBoardRepo
    {
        private readonly VirtpubContext _context;
        public ScoreBoardRepo(VirtpubContext context)
        {
            _context = context;
        }

        public async Task<List<ScoreBoardModel>> GetAllScoreboards()
        {
            return await _context.ScoreBoards.ToListAsync();
        }

        public async Task<List<ScoreBoardModel>> GetScoreboardByGameId(Guid sportId)
        {
            return await _context.ScoreBoards.Where(x => x.gameID == sportId).OrderByDescending(z => z.points).ToListAsync();
        }

        public async Task<string> CreateScoreBoard(ScoreBoardModel scoreBoard)
        {
            var scoreboards = await GetScoreboardByGameId(scoreBoard.gameID);
            var highScores = scoreboards.Where(x => x.points > scoreBoard.points);
            if (highScores.Count() < 6)
            {
                _context.ScoreBoards.Add(scoreBoard);
                var result = await _context.SaveChangesAsync();

                if (result <= 0)
                {
                    return "Something went wrong";
                }

                return "Scoreboard created";
            }

            return "Not enough points to be added";
        }
    }
}
