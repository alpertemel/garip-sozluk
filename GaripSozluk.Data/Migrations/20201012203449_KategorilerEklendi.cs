using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GaripSozluk.Data.Migrations
{
    public partial class KategorilerEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "08276cdb-f123-43ad-b1ca-b53ebb970f71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f3a09c27-c93d-4731-b0f6-aacea20a08ab");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 12, 23, 34, 49, 98, DateTimeKind.Local).AddTicks(7209), "Gündem", null },
                    { 2, new DateTime(2020, 10, 12, 23, 34, 49, 100, DateTimeKind.Local).AddTicks(4458), "Debe", null },
                    { 3, new DateTime(2020, 10, 12, 23, 34, 49, 100, DateTimeKind.Local).AddTicks(4506), "Sorunsallar", null },
                    { 4, new DateTime(2020, 10, 12, 23, 34, 49, 100, DateTimeKind.Local).AddTicks(4509), "#Spor", null },
                    { 5, new DateTime(2020, 10, 12, 23, 34, 49, 100, DateTimeKind.Local).AddTicks(4511), "#İlişkiler", null },
                    { 6, new DateTime(2020, 10, 12, 23, 34, 49, 100, DateTimeKind.Local).AddTicks(4517), "#Siyaset", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "49e03606-a78a-4ec0-979e-c83d08953d6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a474daaf-eea6-4ac0-9e5c-7aa996a926fa");
        }
    }
}
