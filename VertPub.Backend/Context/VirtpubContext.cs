﻿using Microsoft.EntityFrameworkCore;
using VertPub.Backend.Models;

namespace VertPub.Backend.Context
{
    public class VirtpubContext:DbContext
    {
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<ScoreBoardModel> ScoreBoards { get; set; }
        public DbSet<GameLinksModel> GameLinks { get; set; }

        public VirtpubContext(DbContextOptions options) : base(options)
        {

        }
    }
}
