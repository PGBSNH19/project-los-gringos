using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<TableModel>>> GetAllTables()
        {
            var result = await _repo.GetAllTables();
            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTable([FromBody] TableModel table)
        {
            var result = await _repo.CreateTable(table);
            return Ok(result);
        }
    }
}




