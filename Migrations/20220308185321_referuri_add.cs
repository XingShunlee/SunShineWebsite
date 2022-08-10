using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class referuri_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferUri",
                table: "ItBlogSets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferUri",
                table: "GameStrategs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferUri",
                table: "ItBlogSets");

            migrationBuilder.DropColumn(
                name: "ReferUri",
                table: "GameStrategs");
        }
    }
}
