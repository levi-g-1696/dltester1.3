using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 21);

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionID", "CreationDate", "DestinationID", "ExpirationDate", "HasConfirmation", "IsEnable", "MonitorListID", "Name", "OutputTypeID", "Pause", "Repeat", "SpecHeaderID", "StartOnEnable", "StartTime", "TimingBase", "UserID", "ValTimesID" },
                values: new object[] { 1, null, null, null, null, null, null, "Untiteled", null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 22,
                columns: new[] { "CreationDate", "ExpirationDate", "IsAdmin", "UserName" },
                values: new object[] { new DateTime(2022, 5, 9, 22, 36, 32, 592, DateTimeKind.Local).AddTicks(566), new DateTime(2022, 5, 10, 22, 36, 32, 592, DateTimeKind.Local).AddTicks(569), false, "user2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 5, 9, 22, 36, 32, 585, DateTimeKind.Local).AddTicks(4855), new DateTime(2022, 5, 10, 22, 36, 32, 591, DateTimeKind.Local).AddTicks(9330), true, true, "Aa12345", "admin" },
                    { 11, new DateTime(2022, 5, 9, 22, 36, 32, 592, DateTimeKind.Local).AddTicks(543), new DateTime(2022, 5, 10, 22, 36, 32, 592, DateTimeKind.Local).AddTicks(560), false, true, "1234", "user1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 22,
                columns: new[] { "CreationDate", "ExpirationDate", "IsAdmin", "UserName" },
                values: new object[] { new DateTime(2022, 5, 9, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8014), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8021), true, "user4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[] { 21, new DateTime(2022, 5, 9, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(7955), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8001), true, true, "1234", "user3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[] { 20, new DateTime(2022, 5, 9, 21, 52, 50, 904, DateTimeKind.Local).AddTicks(1806), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(6135), true, true, "Aa12345", "admin2" });
        }
    }
}
