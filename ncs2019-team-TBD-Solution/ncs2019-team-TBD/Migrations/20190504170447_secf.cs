using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ncs2019_team_TBD.Migrations
{
    public partial class secf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 894, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 374, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 887, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 367, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 885, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 365, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 882, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 362, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 896, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 376, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 374, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 894, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 367, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 887, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 365, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 885, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 362, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 882, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 12, 37, 34, 376, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 896, DateTimeKind.Utc));
        }
    }
}
