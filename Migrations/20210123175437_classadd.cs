using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class classadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "isValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "isMailValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "isIdentityValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "VipLevel",
                table: "GameStrategs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lookupvalue",
                table: "GameStrategs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupBinderTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ControllerNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnPermissions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupBinderTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsValidatedOK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActionNo = table.Column<int>(nullable: false),
                    ControllerNo = table.Column<int>(nullable: false),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isGet = table.Column<int>(nullable: false),
                    ShowInManagerBar = table.Column<int>(nullable: false),
                    VisitLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleBinderTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ControllerNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnPermissions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleBinderTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsValidatedOK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupBinderTable");

            migrationBuilder.DropTable(
                name: "GroupTable");

            migrationBuilder.DropTable(
                name: "PermissionTable");

            migrationBuilder.DropTable(
                name: "RoleBinderTable");

            migrationBuilder.DropTable(
                name: "RoleTable");

            migrationBuilder.DropColumn(
                name: "VipLevel",
                table: "GameStrategs");

            migrationBuilder.DropColumn(
                name: "lookupvalue",
                table: "GameStrategs");

            migrationBuilder.AlterColumn<short>(
                name: "isValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "isMailValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "isIdentityValid",
                table: "MemberShipInfomation",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
