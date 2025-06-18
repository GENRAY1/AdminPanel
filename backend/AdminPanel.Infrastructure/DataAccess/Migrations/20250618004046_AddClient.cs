using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminPanel.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTag",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTag", x => new { x.ClientId, x.Tag });
                    table.ForeignKey(
                        name: "FK_ClientTag_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "Balance", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 200000m, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), "contact@rogakopyta.ru", "ООО 'Рога и Копыта'", new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 500000.11m, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ivan.petrov@example.com", "Иван Петров", null },
                    { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 100000m, new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), "contact@globalinvest.ru", "ООО 'Глобал Инвест'", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTag");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
