using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Repos
{
    public interface ITableRepo
    {
        Task<string> CreateTable(TableModel table);
        Task<List<TableModel>> GetAllTables();
    }
}