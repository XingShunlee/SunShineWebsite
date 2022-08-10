using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class blogsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    LoginIP = table.Column<string>(nullable: true),
                    LoginGuid = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    sPermission = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdministratorID);
                });

            migrationBuilder.CreateTable(
                name: "chatRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    kfUserId = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: false),
                    customerContent = table.Column<string>(nullable: true),
                    kfContent = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatRecords", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "CommentTable",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    GameStrateID = table.Column<int>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    IsChecked = table.Column<int>(nullable: false)
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
                        .Annotation("MySQL:AutoIncrement", true),
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
                    EndTime = table.Column<DateTime>(nullable: false),
                    Announcer = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    IsIdentified = table.Column<int>(nullable: false),
                    AuthorID = table.Column<int>(nullable: false)
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
                        .Annotation("MySQL:AutoIncrement", true),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    toplevel = table.Column<int>(nullable: false),
                    readers = table.Column<int>(nullable: false),
                    IsIdentified = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    VipLevel = table.Column<int>(nullable: false),
                    lookupvalue = table.Column<int>(nullable: false),
                    IsUnVisible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStrategs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.GameId);
                });

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
                name: "ItBlogSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    blogtype = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    toplevel = table.Column<int>(nullable: false),
                    readers = table.Column<int>(nullable: false),
                    IsIdentified = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    VipLevel = table.Column<int>(nullable: false),
                    lookupvalue = table.Column<int>(nullable: false),
                    IsUnVisible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItBlogSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kefu_customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    customerId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    isOnline = table.Column<int>(nullable: false),
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
                        .Annotation("MySQL:AutoIncrement", true),
                    kfUserId = table.Column<int>(nullable: false),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    isOnline = table.Column<int>(nullable: false),
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
                        .Annotation("MySQL:AutoIncrement", true),
                    UserGuid = table.Column<string>(nullable: true),
                    UMoney = table.Column<decimal>(nullable: false),
                    TMoney = table.Column<decimal>(nullable: false),
                    isValid = table.Column<int>(nullable: false),
                    isMailValid = table.Column<int>(nullable: false),
                    isIdentityValid = table.Column<int>(nullable: false),
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
                        .Annotation("MySQL:AutoIncrement", true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    LoginIP = table.Column<string>(nullable: true),
                    LoginGuid = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    VIPLevel = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 11, nullable: true),
                    SignCount = table.Column<int>(nullable: false),
                    LastSignTime = table.Column<DateTime>(nullable: true),
                    sPermission = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    nStatus = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemShips", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MyGames",
                columns: table => new
                {
                    IndexID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    Gametype = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGames", x => x.IndexID);
                });

            migrationBuilder.CreateTable(
                name: "MyGameStrages",
                columns: table => new
                {
                    IndexID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    Gametype = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGameStrages", x => x.IndexID);
                });

            migrationBuilder.CreateTable(
                name: "MyItBlogs",
                columns: table => new
                {
                    IndexID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BlogID = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    blogtype = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyItBlogs", x => x.IndexID);
                });

            migrationBuilder.CreateTable(
                name: "PayBillApproveModels",
                columns: table => new
                {
                    PayBillApproveID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PayBillID = table.Column<int>(nullable: false),
                    ApproveForWhat = table.Column<string>(nullable: true),
                    PayType = table.Column<int>(nullable: false),
                    PayState = table.Column<int>(nullable: false),
                    PayForDateTime = table.Column<DateTime>(nullable: false),
                    ApproveDeleteMask = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    PayValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayBillApproveModels", x => x.PayBillApproveID);
                });

            migrationBuilder.CreateTable(
                name: "PayBillModels",
                columns: table => new
                {
                    PayBillID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    PayForWhat = table.Column<string>(nullable: true),
                    PayType = table.Column<int>(nullable: false),
                    PayIdentity = table.Column<string>(nullable: true),
                    PayState = table.Column<int>(nullable: false),
                    PayValue = table.Column<int>(nullable: false),
                    PayForDateTime = table.Column<DateTime>(nullable: false),
                    PayDeleteMask = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayBillModels", x => x.PayBillID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GlobalNo = table.Column<int>(nullable: false),
                    ChineseActionName = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SupplierItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
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
                        .Annotation("MySQL:AutoIncrement", true),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    ReleaseTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    NewsTypeId = table.Column<int>(nullable: false),
                    Announcer = table.Column<string>(nullable: true),
                    ReferAthor = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    toplevel = table.Column<int>(nullable: false),
                    readers = table.Column<int>(nullable: false),
                    IsUnVisible = table.Column<int>(nullable: false)
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
                name: "GroupBinderTable");

            migrationBuilder.DropTable(
                name: "GroupTable");

            migrationBuilder.DropTable(
                name: "ItBlogSets");

            migrationBuilder.DropTable(
                name: "kefu_customers");

            migrationBuilder.DropTable(
                name: "kefu_StatusService");

            migrationBuilder.DropTable(
                name: "MemberShipInfomation");

            migrationBuilder.DropTable(
                name: "MemShips");

            migrationBuilder.DropTable(
                name: "MyGames");

            migrationBuilder.DropTable(
                name: "MyGameStrages");

            migrationBuilder.DropTable(
                name: "MyItBlogs");

            migrationBuilder.DropTable(
                name: "PayBillApproveModels");

            migrationBuilder.DropTable(
                name: "PayBillModels");

            migrationBuilder.DropTable(
                name: "PermissionTable");

            migrationBuilder.DropTable(
                name: "RoleBinderTable");

            migrationBuilder.DropTable(
                name: "RoleTable");

            migrationBuilder.DropTable(
                name: "SupplierItems");

            migrationBuilder.DropTable(
                name: "WebNewses");
        }
    }
}
