using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class gamelists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Announcer",
                table: "GameLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferAthor",
                table: "GameLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Announcer",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "ReferAthor",
                table: "GameLists");
        }
    }
}
