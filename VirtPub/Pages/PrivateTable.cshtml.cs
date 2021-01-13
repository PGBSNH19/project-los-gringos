using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserService _service;
        private readonly GameService _gameService;
        public List<GameLinksModel> Games = new List<GameLinksModel>();
        public List<ConnectedUser> UserList = new List<ConnectedUser>();

        public PrivateTableModel(UserService service, GameService gameService)
        {
            _service = service;
            _gameService = gameService;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if(Id == Guid.Empty)
                return RedirectToPage("/Index");

            Games = await _gameService.GetGames();

            UserList = _service.GetUsersInTableById(Id.ToString());
            return Page();
        }

        public PartialViewResult OnGetUserListPartial(string tableId)
        {
            return Partial("_UserListPartial", _service.GetUsersInTableById(tableId).OrderByDescending(x => x.Score).ToList());
        }
    }
}
