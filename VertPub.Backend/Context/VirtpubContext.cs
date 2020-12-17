using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertPub.Backend.Models;

namespace VertPub.Backend.Context
{
    public class VirtpubContext:DbContext
    {
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<ScoreBoard> ScoreBoards { get; set; }
        public DbSet<GameLinksModel> GameLinks { get; set; }

        public VirtpubContext(DbContextOptions options) : base(options)
        {

        }
    }
}
