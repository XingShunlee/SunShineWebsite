using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class loginstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoginGuid",
                table: "MemShips",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoginGuid",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginGuid",
                table: "MemShips");

            migrationBuilder.DropColumn(
                name: "LoginGuid",
                table: "Admin");
        }
    }
}
