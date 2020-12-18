using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GameService _service;
        public IEnumerable<GameModel> games = new List<GameModel>();


        public IndexModel(ILogger<IndexModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet()
        {
            games = await _service.GetGames();
        }

        public void OnPost()
        {
        }
    }
}
