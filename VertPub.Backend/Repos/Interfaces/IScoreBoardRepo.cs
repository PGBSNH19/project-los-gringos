using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public interface IScoreBoardRepo
    {
        Task<List<ScoreBoardModel>> GetAllScoreboards();
        Task<string> CreateScoreBoard(ScoreBoardModel scoreBoard);
        Task<List<ScoreBoardModel>> GetScoreboardByGameId(Guid id);
    }
}