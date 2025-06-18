using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminPanel.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentAndRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    RateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTag",
                columns: new[] { "ClientId", "Tag" },
                values: new object[,]
                {
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 1 },
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 2 },
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 3 },
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 6 },
                    { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 7 },
                    { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 1 },
                    { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 3 },
                    { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 7 },
                    { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 4 },
                    { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 5 },
                    { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 8 }
                });

            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "Id", "CreatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("000fe0dc-5c77-4f7d-a97a-337d54bf34fa"), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 86m },
                    { new Guid("1224c302-d8ce-4bf6-bf0f-c8fdce929f67"), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 113m },
                    { new Guid("1c418e7a-9d11-4f65-bca1-f193c1eb5a6c"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 109m },
                    { new Guid("376a4fb5-9a56-458f-b6dc-82f9879abf1e"), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 120m },
                    { new Guid("ad092827-b3d3-4971-b1a0-0cb7e93c733f"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 51m },
                    { new Guid("aecae947-96fa-4891-8fc1-6cdef3c8b8bf"), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), 179m },
                    { new Guid("af9ee87c-c49c-4935-95af-fdbf850bc455"), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 201m },
                    { new Guid("c96fd987-8f25-4cd3-af6e-45e9fa7f4c0c"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 140m },
                    { new Guid("d7a8b7ea-d0ca-468a-8d1c-ff421eb15463"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100m },
                    { new Guid("f704312b-9da0-48ee-bd0b-a90a4d1c7644"), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 94m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ClientId",
                table: "Payment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreatedAt",
                table: "Payment",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_RateId",
                table: "Payment",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_CreatedAt",
                table: "Rate",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 1 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 2 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 3 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 6 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), 7 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 1 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 3 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), 7 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 4 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 5 });

            migrationBuilder.DeleteData(
                table: "ClientTag",
                keyColumns: new[] { "ClientId", "Tag" },
                keyValues: new object[] { new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), 8 });
        }
    }
}
