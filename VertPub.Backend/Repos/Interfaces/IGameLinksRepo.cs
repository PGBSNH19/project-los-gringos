using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public interface IGameLinksRepo
    {
        Task<string> AddGame(GameLinksModel game);
        Task<List<GameLinksModel>> GetAllGames();
    }
}