using Microsoft.EntityFrameworkCore.Migrations;

namespace ehaikerv202010.Migrations
{
    public partial class commentadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayDeleteMask",
                table: "PayBillModels",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "ApproveDeleteMask",
                table: "PayBillApproveModels",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "isOnline",
                table: "kefu_StatusService",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "isOnline",
                table: "kefu_customers",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CommentTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsChecked",
                table: "CommentTable",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "GameStrateID",
                table: "CommentTable",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameStrateID",
                table: "CommentTable");

            migrationBuilder.AlterColumn<short>(
                name: "PayDeleteMask",
                table: "PayBillModels",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "ApproveDeleteMask",
                table: "PayBillApproveModels",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "isOnline",
                table: "kefu_StatusService",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "isOnline",
                table: "kefu_customers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentTable",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "IsChecked",
                table: "CommentTable",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
