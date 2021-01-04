using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertPub.Backend.Migrations
{
    public partial class scorebordfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_GameLinks_gameid",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_gameid",
                table: "ScoreBoards");

            migrationBuilder.RenameColumn(
                name: "gameid",
                table: "ScoreBoards",
                newName: "gameID");

            migrationBuilder.AlterColumn<Guid>(
                name: "gameID",
                table: "ScoreBoards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gameID",
                table: "ScoreBoards",
                newName: "gameid");

            migrationBuilder.AlterColumn<Guid>(
                name: "gameid",
                table: "ScoreBoards",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
    }
}
