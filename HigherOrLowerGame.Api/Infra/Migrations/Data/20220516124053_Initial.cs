using System;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;
#nullable disable

namespace HigherOrLowerGame.Api.Infra.Migrations.Data
{
    [ExcludeFromCodeCoverage]
    public partial class Initial : Migration
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
                    CurrentPlayer = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<string>(type: "text", nullable: false),
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
