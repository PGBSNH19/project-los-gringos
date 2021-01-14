using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertPub.Backend.Models;
using VertPub.Backend.Repos;

namespace VertPub.Backend.Controllers
{

    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepo _repo;
        public TableController(ITableRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetTableById")]
        public async Task<ActionResult<List<GameLinksModel>>> GetTableById(string id)
        {
            var result = await _repo.GetTableById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetTablesLinkedToGame")]
        public async Task<ActionResult<List<TableModel>>> GetTablesLinkedToGame(string id)
        {
            var result = await _repo.GetTablesLinkedToGame(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TableModel>>> GetAllTables()
        {
            var result = await _repo.GetAllTables();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<int> DeleteTable(Guid id) 
        {
            return await _repo.DeleteTable(id);
        }
        [HttpPost]
        public async Task<ActionResult<string>> CreateTable([FromBody] TableModel table)
        {
            var result = await _repo.CreateTable(table);
            return Ok(result);
        }
    }
}




