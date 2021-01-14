using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Context;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public class GameLinksRepo : IGameLinksRepo
    {
        private readonly VirtpubContext _context;
        public GameLinksRepo(VirtpubContext context)
        {
            _context = context;
        }
        public async Task<List<GameLinksModel>> GetAllGames()
        {
            var games = await _context.GameLinks.ToListAsync();
            return games;
        }

        public async Task<string> AddGame(GameLinksModel game)
        {
            _context.GameLinks.Add(game);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return "Game created";
            }
            return "Something went wrong game not created";
        }

        public async Task<GameLinksModel> GetGameById(string id)
        {
            var game = await _context.GameLinks.FirstOrDefaultAsync(x => x.id.ToString() == id);
            return game;
        }
    }
}
