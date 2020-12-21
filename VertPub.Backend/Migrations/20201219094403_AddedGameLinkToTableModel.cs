using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertPub.Backend.Migrations
{
    public partial class AddedGameLinkToTableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameLinks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maxPlayers = table.Column<int>(type: "int", nullable: false),
                    minPlayers = table.Column<int>(type: "int", nullable: false)
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
                    gameid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    points = table.Column<int>(type: "int", nullable: false),
                    player = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreBoards", x => x.id);
                    table.ForeignKey(
                        name: "FK_ScoreBoards_GameLinks_gameid",
                        column: x => x.gameid,
                        principalTable: "GameLinks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false),
                    gameid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tables_GameLinks_gameid",
                        column: x => x.gameid,
                        principalTable: "GameLinks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_gameid",
                table: "ScoreBoards",
                column: "gameid");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_gameid",
                table: "Tables",
                column: "gameid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreBoards");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "GameLinks");
        }
    }
}
