using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public interface IScoreBoardRepo
    {
        Task<string> CreateScoreBoard(ScoreBoardModel scoreBoard);
        Task<List<ScoreBoardModel>> GetAllScorbords();
        Task<string> ChangeScoreboard(string name, int points,Guid id);
        Task<List<ScoreBoardModel>> GetScoreboardByGameId(Guid id);
    }
}