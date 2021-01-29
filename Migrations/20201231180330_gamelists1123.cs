using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class gamelists1123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "GameStrategs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsIdentified",
                table: "GameStrategs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "GameLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsIdentified",
                table: "GameLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "GameStrategs");

            migrationBuilder.DropColumn(
                name: "IsIdentified",
                table: "GameStrategs");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "IsIdentified",
                table: "GameLists");
        }
    }
}
