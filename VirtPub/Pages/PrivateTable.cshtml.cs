using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Pages
{
    [Authorize]
    public class PrivateTableModel : PageModel
    {
        private readonly GameService _service;
        public List<GameLinksModel> Games = new List<GameLinksModel>();

        public PrivateTableModel(GameService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if(Id== Guid.Empty)
                return RedirectToPage("/Index");

            Games = await _service.GetGames();
            return Page();
        }

    }
}
