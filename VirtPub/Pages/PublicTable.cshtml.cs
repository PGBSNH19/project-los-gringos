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
    public class PublicTableModel : PageModel
    {
        private readonly ILogger<PublicTableModel> _logger;
        public GameService _service;
        public IEnumerable<TableModel> Tables = new List<TableModel>();
        public GameLinksModel Game = new GameLinksModel();
        public List<ConnectedUser> UserList = new List<ConnectedUser>();

        public PublicTableModel(ILogger<PublicTableModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet(Dictionary<string, string> selectedGame)
        {
            Game = await _service.GetGameById(selectedGame["id"]);
            Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);

            //if (Tables == null || Tables.Count() < 1)
            //{
            //    await _service.CreateTable(Game);
            //    Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);
            //}
            var fullTables = 0;
            var emtyTables = new List<Guid>();
            foreach (var table in Tables)
            {
                var peopleOnTable = _service.GetUsersInTableById(table.id.ToString()).Count();
                if (Game.maxPlayers <= peopleOnTable)
                {
                    fullTables++;
                }
                if (peopleOnTable == 0)
                {
                    emtyTables.Add(table.id);
                }
            }
            foreach (var item in emtyTables)
            {
                await _service.RemoveTableByID(item);

            }
            if (fullTables == Tables.Count())
            {
                await _service.CreateTable(Game);
                Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);
            }


        }
    }
}