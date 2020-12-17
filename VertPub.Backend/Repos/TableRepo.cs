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

        public async Task<List<TableModel>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<string> CreateTable(TableModel table)
        {
            _context.Tables.Add(table);
            var result = await _context.SaveChangesAsync();
            if (result < 0)
            {
                return "something went wrong";
            }
            return "table created";
        }
    }
}
