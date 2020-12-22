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
    public class PublicTableModel : PageModel
    {
        private readonly ILogger<PublicTableModel> _logger;
        private readonly GameService _service;
        public IEnumerable<TableModel> Tables = new List<TableModel>();

        public GameLinksModel Game = new GameLinksModel();

        public PublicTableModel(ILogger<PublicTableModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }
        
        public async Task OnGet(Dictionary<string, string> selectedGame)
        {
            Game = await _service.GetGameById(selectedGame["id"]);
            Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);

            if (Tables == null || Tables.Count() < 1)
            {
                await _service.CreateTable(Game);
                Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);
            }
        }
    }
}