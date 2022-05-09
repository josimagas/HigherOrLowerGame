using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HigherOrLowerGameApi.API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstPlayerScore = table.Column<int>(type: "integer", nullable: false),
                    SecondPlayerScore = table.Column<int>(type: "integer", nullable: false),
                    NumberOfCardOnDeck = table.Column<int>(type: "integer", nullable: false),
                    CurrentCardValue = table.Column<int>(type: "integer", nullable: false),
                    CurrentPlayer = table.Column<string>(type: "text", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
