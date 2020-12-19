using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Pages
{
    public class PublicTableGameModel : PageModel
    {
        private readonly ILogger<PublicTableModel> _logger;
        private readonly GameService _service;
        public TableModel Table = new TableModel();

        public PublicTableGameModel(ILogger<PublicTableModel> logger, GameService service)
        {
            _logger = logger;
            _service = service;
        }
        
        public async Task OnGet(Dictionary<string, string> selectedTable)
        {
            Table = await _service.GetTableById(selectedTable["id"]);
        }
    }
}