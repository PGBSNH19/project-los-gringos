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
        private readonly GameService _service;
        [BindProperty]
        public Guid Id { get; set; }
        public IEnumerable<GameLinksModel> Games = new List<GameLinksModel>();


        public IndexModel(ILogger<IndexModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet()
        {
            Games = await _service.GetGames();
            //Games= null;
        }

        public void OnPost()
        {
            Id= Guid.NewGuid();
        }
    }
}
