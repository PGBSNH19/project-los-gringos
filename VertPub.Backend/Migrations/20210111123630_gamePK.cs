using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertPub.Backend.Migrations
{
    public partial class gamePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_GameLinks_gameid",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_gameid",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "gameid",
                table: "Tables",
                newName: "gameID");

            migrationBuilder.AlterColumn<Guid>(
                name: "gameID",
                table: "Tables",
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
                table: "Tables",
                newName: "gameid");

            migrationBuilder.AlterColumn<Guid>(
                name: "gameid",
                table: "Tables",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_gameid",
                table: "Tables",
                column: "gameid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_GameLinks_gameid",
                table: "Tables",
                column: "gameid",
                principalTable: "GameLinks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
