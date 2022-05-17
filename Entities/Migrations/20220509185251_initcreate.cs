using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataScheduals",
                columns: table => new
                {
                    SchedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionID = table.Column<int>(type: "int", nullable: true),
                    IsSent = table.Column<bool>(type: "bit", nullable: true),
                    WasErrorOnSending = table.Column<bool>(type: "bit", nullable: true),
                    RepeatCounter = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    monitorsVal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataScheduals", x => x.SchedID);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtocolType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    SrvUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SrvPassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Protocolid = table.Column<int>(type: "int", nullable: true),
                    IPaddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VirtualPath = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationID);
                });

            migrationBuilder.CreateTable(
                name: "MonitorLists",
                columns: table => new
                {
                    MonListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MonitorNames = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorLists", x => x.MonListID);
                });

            migrationBuilder.CreateTable(
                name: "OutputTypes",
                columns: table => new
                {
                    OutputTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputTypes", x => x.OutputTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialHeaders",
                columns: table => new
                {
                    SpecHeaderID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialHeaders", x => x.SpecHeaderID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ValuesTimes",
                columns: table => new
                {
                    ValTimesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DuringTime = table.Column<double>(type: "float", nullable: true),
                    MonFrom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MonTo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MonListID = table.Column<int>(type: "int", nullable: true),
                    MonNames = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuesTimes_1", x => x.ValTimesID);
                    table.ForeignKey(
                        name: "FK_ValuesTimes_MonitorLists",
                        column: x => x.MonListID,
                        principalTable: "MonitorLists",
                        principalColumn: "MonListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OutputTypeID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsEnable = table.Column<bool>(type: "bit", nullable: true),
                    HasConfirmation = table.Column<bool>(type: "bit", nullable: true),
                    MonitorListID = table.Column<int>(type: "int", nullable: true),
                    Repeat = table.Column<int>(type: "int", nullable: true),
                    Pause = table.Column<double>(type: "float", nullable: true),
                    TimingBase = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    StartOnEnable = table.Column<bool>(type: "bit", nullable: true),
                    SpecHeaderID = table.Column<int>(type: "int", nullable: true),
                    ValTimesID = table.Column<int>(type: "int", nullable: true),
                    DestinationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sessions_Destinations",
                        column: x => x.DestinationID,
                        principalTable: "Destinations",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_MonitorLists",
                        column: x => x.MonitorListID,
                        principalTable: "MonitorLists",
                        principalColumn: "MonListID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_OutputTypes",
                        column: x => x.OutputTypeID,
                        principalTable: "OutputTypes",
                        principalColumn: "OutputTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_SpecialHeaders",
                        column: x => x.SpecHeaderID,
                        principalTable: "SpecialHeaders",
                        principalColumn: "SpecHeaderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[] { 20, new DateTime(2022, 5, 9, 21, 52, 50, 904, DateTimeKind.Local).AddTicks(1806), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(6135), true, true, "Aa12345", "admin2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[] { 21, new DateTime(2022, 5, 9, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(7955), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8001), true, true, "1234", "user3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "ExpirationDate", "IsAdmin", "IsEnable", "Password", "UserName" },
                values: new object[] { 22, new DateTime(2022, 5, 9, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8014), new DateTime(2022, 5, 10, 21, 52, 50, 908, DateTimeKind.Local).AddTicks(8021), true, true, "1234", "user4" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_DestinationID",
                table: "Sessions",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MonitorListID",
                table: "Sessions",
                column: "MonitorListID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_OutputTypeID",
                table: "Sessions",
                column: "OutputTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpecHeaderID",
                table: "Sessions",
                column: "SpecHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserID",
                table: "Sessions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuesTimes_MonListID",
                table: "ValuesTimes",
                column: "MonListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataScheduals");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ValuesTimes");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "OutputTypes");

            migrationBuilder.DropTable(
                name: "SpecialHeaders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MonitorLists");
        }
    }
}
