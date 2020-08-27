using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalManager2.Migrations
{
    public partial class createdMembrosAndPgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Membros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "Membros",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PGId",
                table: "Membros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isLiderPG",
                table: "Membros",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membros_PGId",
                table: "Membros",
                column: "PGId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_PGs_PGId",
                table: "Membros",
                column: "PGId",
                principalTable: "PGs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_PGs_PGId",
                table: "Membros");

            migrationBuilder.DropTable(
                name: "PGs");

            migrationBuilder.DropIndex(
                name: "IX_Membros_PGId",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "PGId",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "isLiderPG",
                table: "Membros");
        }
    }
}
