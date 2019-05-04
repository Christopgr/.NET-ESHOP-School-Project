using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ncs2019_team_TBD.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 167, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 240, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 172, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 246, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 171, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 243, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 169, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 241, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 175, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 249, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 240, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 167, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 246, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 172, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 243, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 171, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 241, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 169, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 1, 16, 34, 20, 249, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 5, 16, 25, 175, DateTimeKind.Utc));
        }
    }
}
