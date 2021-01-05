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

        public async Task<List<ScoreBoardModel>> GetScoreboardByGameId(Guid id) 
        {
             return await _context.ScoreBoards.Where(x=>x.gameID==id).OrderByDescending(z=>z.points).ToListAsync();
        }
        public async Task<string> ChangeScoreboard(string name,int points,Guid id)
        {
            var scoreboards = await GetScoreboardByGameId(id);
            var highscores = scoreboards.Where(x => x.points > points);
            if (highscores.Count() < 6)
            {
                var test = await CreateScoreBoard(new ScoreBoardModel
                {
                    points = points,
                    gameID = id,
                    player = name
                }) ;
            return "scoreboard uppdated";
            }

            return "no changes wher made";

        }
    }
}
