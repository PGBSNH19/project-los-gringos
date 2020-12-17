using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertPub.Backend.Migrations
{
    public partial class relationscoreboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "game",
                table: "ScoreBoards");

            migrationBuilder.AddColumn<Guid>(
                name: "gameid",
                table: "ScoreBoards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_gameid",
                table: "ScoreBoards",
                column: "gameid");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoards_GameLinks_gameid",
                table: "ScoreBoards",
                column: "gameid",
                principalTable: "GameLinks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_GameLinks_gameid",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_gameid",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "gameid",
                table: "ScoreBoards");

            migrationBuilder.AddColumn<string>(
                name: "game",
                table: "ScoreBoards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
