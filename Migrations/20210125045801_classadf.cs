using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class classadf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "PermissionTable");

            migrationBuilder.DropColumn(
                name: "ActionNo",
                table: "PermissionTable");

            migrationBuilder.RenameColumn(
                name: "ControllerNo",
                table: "PermissionTable",
                newName: "GlobalNo");

            migrationBuilder.RenameColumn(
                name: "ControllerName",
                table: "PermissionTable",
                newName: "ChineseActionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GlobalNo",
                table: "PermissionTable",
                newName: "ControllerNo");

            migrationBuilder.RenameColumn(
                name: "ChineseActionName",
                table: "PermissionTable",
                newName: "ControllerName");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "PermissionTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActionNo",
                table: "PermissionTable",
                nullable: false,
                defaultValue: 0);
        }
    }
}
