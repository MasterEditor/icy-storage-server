using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IcyStorageServer.Migrations
{
    public partial class AddNodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyTimestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FSNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FSNodes_FSNodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FSNodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FSNodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FSNodes_ParentId",
                table: "FSNodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FSNodes_UserId",
                table: "FSNodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FSNodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
