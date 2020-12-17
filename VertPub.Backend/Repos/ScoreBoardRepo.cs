using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ScoreBoardModel>> GetAllScorbords()
        {
            return await _context.ScoreBoards.ToListAsync();
        }
        public async Task<string> CreateScoreBoard(ScoreBoardModel scoreBoard)
        {
            _context.ScoreBoards.Add(scoreBoard);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                return "something went wrong";
            }
            return "Scoreboard created";
        }
    }
}
