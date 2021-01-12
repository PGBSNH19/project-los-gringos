using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
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
        public  ScoreboardService _service;
        private readonly GameService _gameService;

        [BindProperty]
        public Guid Id { get; set; }
        public IEnumerable<GameLinksModel> Games = new List<GameLinksModel>();


        public IndexModel(ILogger<IndexModel> logger, ScoreboardService service, GameService gameService)
        {
            _logger = logger;
            _service = service;
            _gameService = gameService;
        }

        public async Task OnGet()
        {
            Games = await _gameService.GetGames();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/PrivateTable", new {Id = Guid.NewGuid()});
        }
    }
}
