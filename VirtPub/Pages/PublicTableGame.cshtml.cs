using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class PublicTableGameModel : PageModel
    {
        private readonly ILogger<PublicTableModel> _logger;

        private readonly UserService _service;
        private readonly TableService _tableService;
        private readonly GameService _gameService;
        public TableModel Table = new TableModel();
        public GameLinksModel Game = new GameLinksModel();
        public List<ConnectedUser> UserList = new List<ConnectedUser>();

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty(SupportsGet= true)]
        public Dictionary<string,string> SelectedTable {get; set;}
        public PublicTableGameModel(ILogger<PublicTableModel> logger, UserService service, TableService tableService, GameService gameService)
        {
            _logger = logger;
            _service = service;
            _tableService = tableService;
            _gameService = gameService;
        }

        public async Task<ActionResult> OnGet()
        {
            var id = SelectedTable["id"];
            Table = await _tableService.GetTableById(SelectedTable["id"]);
            Game = await _gameService.GetGameById(Table.gameID.ToString());
            UserList = _service.GetUsersInTableById(Id.ToString());
            if (UserList.Count>=Game.maxPlayers)
            {
                 return RedirectToPage("/Index");
            }
            return null;
        }

        public PartialViewResult OnGetUserListPartial(string tableId)
        {
            return Partial("_UserListPartial", _service.GetUsersInTableById(tableId));
        }
    }
}
