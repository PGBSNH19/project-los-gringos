using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public interface ITableRepo
    {
        Task<string> CreateTable(TableModel table);
        Task<int> DeleteTable(Guid id);
        Task<List<TableModel>> GetAllTables();
        Task<List<TableModel>> GetTablesLinkedToGame(string id);
        Task<TableModel> GetTableById(string id);
    }
}