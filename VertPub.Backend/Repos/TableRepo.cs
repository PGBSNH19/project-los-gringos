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
            var table = await _context.Tables.FirstOrDefaultAsync(x => x.id.ToString() == id);
            return table;
        }

        public async Task<List<TableModel>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<List<TableModel>> GetTablesLinkedToGame(string id)
        {
            return await _context.Tables.Where(x => x.gameID.ToString() == id).ToListAsync();
        }

        public async Task<string> CreateTable(TableModel table)
        {
            
            await _context.Tables.AddAsync(table);
            var result =  await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return "something went wrong";
            }
            return "table created";
        }

        public async Task<int> DeleteTable(Guid id)
        {
            var table= await GetTableById(id.ToString());
            var result =_context.Tables.Remove(table);
            var deletedObjects = await _context.SaveChangesAsync();
                return deletedObjects ;
        }
    }
}
