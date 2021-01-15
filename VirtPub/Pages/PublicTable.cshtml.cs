using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Pages
{
    [Authorize]
    public class PublicTableModel : PageModel
    {
        private readonly ILogger<PublicTableModel> _logger;
        public UserService _service;
        private readonly GameService _gameService;
        private readonly TableService _tableService;
        public IEnumerable<TableModel> Tables = new List<TableModel>();
        public GameLinksModel Game = new GameLinksModel();
        public List<ConnectedUser> UserList = new List<ConnectedUser>();

        public PublicTableModel(ILogger<PublicTableModel> logger, UserService service, GameService gameService, TableService tableService)
        {
            _logger = logger;
            _service = service;
            _gameService = gameService;
            _tableService = tableService;
        }

        public async Task OnGet(Dictionary<string, string> selectedGame)
        {
            Game = await _gameService.GetGameById(selectedGame["id"]);
            Tables = await _tableService.GetTablesLinkedToGame(selectedGame["id"]);

            //if (Tables == null || Tables.Count() < 1)
            //{
            //    await _service.CreateTable(Game);
            //    Tables = await _service.GetTablesLinkedToGame(selectedGame["id"]);
            //}

            var fullTables = 0;
            var emptyTables = new List<Guid>();
            foreach (var table in Tables)
            {
                var peopleOnTable = _service.GetUsersInTableById(table.id.ToString()).Count();
                if (Game.maxPlayers <= peopleOnTable)
                {
                    fullTables++;
                }
                if (peopleOnTable == 0)
                {
                    emptyTables.Add(table.id);
                }
            }


            for (int i = 0; i < emptyTables.Count() - 1; i++)
            {

                await _tableService.RemoveTableByID(emptyTables[i]);
            }

            Tables = await _tableService.GetTablesLinkedToGame(selectedGame["id"]);


            if (fullTables == Tables.Count())
            {
                await _tableService.CreateTable(Game);
                Tables = await _tableService.GetTablesLinkedToGame(selectedGame["id"]);
            }


        }
    }
}
