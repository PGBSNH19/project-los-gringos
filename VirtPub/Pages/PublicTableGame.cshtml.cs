using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public PublicTableGameModel(ILogger<PublicTableModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }
        
        public async Task OnGet(Dictionary<string, string> selectedTable)
        {
            Table = await _service.GetTableById(selectedTable["id"]);
            //Game = await _service.GetGameById(Table.game.id.ToString());
        }
    }
}