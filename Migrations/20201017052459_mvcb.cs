using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class mvcb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    LoginIP = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    sPermission = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdministratorID);
                });

           

            migrationBuilder.CreateTable(
                name: "CommentTable",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameID = table.Column<int>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTable", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "GameLists",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ImgDescUri = table.Column<string>(nullable: true),
                    ImgHoverUri = table.Column<string>(nullable: true),
                    targetUri = table.Column<string>(nullable: true),
                    supporter = table.Column<string>(nullable: true),
                    producer = table.Column<string>(nullable: true),
                    gameDescription = table.Column<string>(nullable: true),
                    resourcefrom = table.Column<string>(nullable: true),
                    MineTime = table.Column<DateTime>(nullable: false),
                    TopLevel = table.Column<int>(nullable: false),
                    grade = table.Column<float>(nullable: false),
                    Gametype = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLists", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "GameStrategs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    toplevel = table.Column<int>(nullable: false),
                    readers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStrategs", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "kefu_customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    customerId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    isOnline = table.Column<bool>(nullable: false),
                    headImg = table.Column<string>(nullable: true),
                    kfUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kefu_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kefu_StatusService",
                columns: table => new
                {
                    kfUserIndex = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    kfUserId = table.Column<int>(nullable: false),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    isOnline = table.Column<bool>(nullable: false),
                    CurrentPeople = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kefu_StatusService", x => x.kfUserIndex);
                });

            migrationBuilder.CreateTable(
                name: "MemberShipInfomation",
                columns: table => new
                {
                    IndexId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UMoney = table.Column<decimal>(nullable: false),
                    TMoney = table.Column<decimal>(nullable: false),
                    isValid = table.Column<bool>(nullable: false),
                    isMailValid = table.Column<bool>(nullable: false),
                    isIdentityValid = table.Column<bool>(nullable: false),
                    IdentityCard = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShipInfomation", x => x.IndexId);
                });

            migrationBuilder.CreateTable(
                name: "MemShips",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    LoginIP = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    VIPLevel = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 11, nullable: true),
                    SignCount = table.Column<int>(nullable: false),
                    LastSignTime = table.Column<DateTime>(nullable: true),
                    sPermission = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemShips", x => x.UserId);
                });

           
            migrationBuilder.CreateTable(
                name: "SupplierItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ImgDescUri = table.Column<string>(nullable: true),
                    ImgHoverUri = table.Column<string>(nullable: true),
                    hrefUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierItems", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "WebNewses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    ReleaseTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    NewsTypeId = table.Column<int>(nullable: false),
                    Announcer = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    toplevel = table.Column<int>(nullable: false),
                    readers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebNewses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "chatRecords");

            migrationBuilder.DropTable(
                name: "CommentTable");

            migrationBuilder.DropTable(
                name: "GameLists");

            migrationBuilder.DropTable(
                name: "GameStrategs");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "kefu_customers");

            migrationBuilder.DropTable(
                name: "kefu_StatusService");

            migrationBuilder.DropTable(
                name: "MemberShipInfomation");

            migrationBuilder.DropTable(
                name: "MemShips");

            migrationBuilder.DropTable(
                name: "PayBillApproveModels");

            migrationBuilder.DropTable(
                name: "PayBillModels");

            migrationBuilder.DropTable(
                name: "SupplierItems");

            migrationBuilder.DropTable(
                name: "WebNewses");
        }
    }
}
