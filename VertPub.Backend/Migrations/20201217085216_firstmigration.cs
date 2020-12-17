using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertPub.Backend.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameLinks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLinks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreBoards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    game = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    points = table.Column<int>(type: "int", nullable: false),
                    player = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreBoards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameLinks");

            migrationBuilder.DropTable(
                name: "ScoreBoards");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
