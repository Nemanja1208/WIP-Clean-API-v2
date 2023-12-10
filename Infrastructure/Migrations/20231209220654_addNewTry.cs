using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("20d92f10-32bb-4f3c-b984-3610ac354d3c"), "AnimalModel", "Tiger" },
                    { new Guid("5ffb0c6a-1364-4f83-b9e6-c9db266c03ff"), "AnimalModel", "Lion" },
                    { new Guid("de8fb6a3-636c-400b-83c7-cf9a8e4bf42f"), "AnimalModel", "Elephant" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { new Guid("3022c044-f477-40b8-a8b6-3b36014b85cf"), "User1", "Password1" },
                    { new Guid("468d4c1b-0806-4f5a-b60b-75fe587fc399"), "User3", "Password3" },
                    { new Guid("698fe0ba-ef7d-4dec-af9b-efa2d59ede6c"), "User2", "Password2" }
                });

            migrationBuilder.InsertData(
                table: "UserAnimals",
                columns: new[] { "AnimalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("20d92f10-32bb-4f3c-b984-3610ac354d3c"), new Guid("3022c044-f477-40b8-a8b6-3b36014b85cf") },
                    { new Guid("5ffb0c6a-1364-4f83-b9e6-c9db266c03ff"), new Guid("3022c044-f477-40b8-a8b6-3b36014b85cf") },
                    { new Guid("de8fb6a3-636c-400b-83c7-cf9a8e4bf42f"), new Guid("468d4c1b-0806-4f5a-b60b-75fe587fc399") },
                    { new Guid("20d92f10-32bb-4f3c-b984-3610ac354d3c"), new Guid("698fe0ba-ef7d-4dec-af9b-efa2d59ede6c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
