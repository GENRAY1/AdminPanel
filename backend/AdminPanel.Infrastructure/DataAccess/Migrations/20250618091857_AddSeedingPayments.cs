using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminPanel.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "ClientId", "CreatedAt", "RateId" },
                values: new object[,]
                {
                    { new Guid("1f3b7d57-7c14-435b-998e-fa500424163a"), 18000m, new Guid("751150d4-8e8e-466f-ac7d-bea47981281e"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("1224c302-d8ce-4bf6-bf0f-c8fdce929f67") },
                    { new Guid("74dfabac-f7bc-4439-a501-dc148a65e94d"), 5000m, new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("376a4fb5-9a56-458f-b6dc-82f9879abf1e") },
                    { new Guid("bb606c86-300b-4bce-8d6a-d1dffb29a588"), 2500m, new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aecae947-96fa-4891-8fc1-6cdef3c8b8bf") },
                    { new Guid("dfe99409-bf0f-444c-bf5d-ba7f7e82cfe1"), 100000m, new Guid("f33b8c2e-9335-419a-a1ca-85d6eb5f5c89"), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c96fd987-8f25-4cd3-af6e-45e9fa7f4c0c") },
                    { new Guid("e71ca437-b0c9-4d84-9817-69a3fedebc17"), 1500.50m, new Guid("e3c4ea0e-3c29-4ffe-82a8-8e72857035f3"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("af9ee87c-c49c-4935-95af-fdbf850bc455") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("1f3b7d57-7c14-435b-998e-fa500424163a"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("74dfabac-f7bc-4439-a501-dc148a65e94d"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("bb606c86-300b-4bce-8d6a-d1dffb29a588"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("dfe99409-bf0f-444c-bf5d-ba7f7e82cfe1"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("e71ca437-b0c9-4d84-9817-69a3fedebc17"));
        }
    }
}
