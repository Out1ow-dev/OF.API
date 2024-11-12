using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrazyApi.Persistence.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NickNameHistories");

            migrationBuilder.DropColumn(
                name: "HWID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SteamID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "WMID",
                table: "Users",
                newName: "SubscriptionLevel");

            migrationBuilder.CreateTable(
                name: "ServersList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServerName = table.Column<string>(type: "TEXT", nullable: false),
                    ServerIp = table.Column<string>(type: "TEXT", nullable: false),
                    ServerPort = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerPassword = table.Column<string>(type: "TEXT", nullable: false),
                    ServerOwnerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServersList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServersList_Users_ServerOwnerId",
                        column: x => x.ServerOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServersList_ServerOwnerId",
                table: "ServersList",
                column: "ServerOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServersList");

            migrationBuilder.RenameColumn(
                name: "SubscriptionLevel",
                table: "Users",
                newName: "WMID");

            migrationBuilder.AddColumn<string>(
                name: "HWID",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SteamID",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NickNameHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EditDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NickNameHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NickNameHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NickNameHistories_UserId",
                table: "NickNameHistories",
                column: "UserId");
        }
    }
}
