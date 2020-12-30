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

        private readonly GameService _service;
        public TableModel Table = new TableModel();
        public GameLinksModel Game = new GameLinksModel();
        public List<ConnectedUser> UserList = new List<ConnectedUser>();

        [BindProperty(SupportsGet= true)]
        public Dictionary<string,string> SelectedTable {get; set;}
        public PublicTableGameModel(ILogger<PublicTableModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }
        
        public async Task OnGet()
        {
            Table = await _service.GetTableById(SelectedTable["id"]);
            Game = await _service.GetGameById(Table.game.id.ToString());
        }
    }
}