using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertPub.Backend.Context;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public class TableRepo : ITableRepo
    {
        private readonly VirtpubContext _context;
        public TableRepo(VirtpubContext context)
        {
            _context = context;
        }

        public async Task<TableModel> GetTableById(string id)
        {
            var table = await _context.Tables.Include(x => x.game).FirstOrDefaultAsync(x => x.id.ToString() == id);
            return table;
        }

        public async Task<List<TableModel>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<List<TableModel>> GetTablesLinkedToGame(string id)
        {
            return await _context.Tables.Where(x => x.game.id.ToString() == id).ToListAsync();
        }

        public async Task<string> CreateTable(TableModel table)
        {
            table.game = await _context.GameLinks.FirstOrDefaultAsync(x => x.id == table.game.id);

            _context.Tables.Add(table);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return "something went wrong";
            }
            return "table created";
        }
    }
}
