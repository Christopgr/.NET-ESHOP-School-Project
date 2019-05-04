using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ncs2019_team_TBD.Migrations
{
    public partial class matpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 528, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 596, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 510, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 626, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 504, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 617, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 498, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 603, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 533, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 635, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 596, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 528, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 626, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 510, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 617, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 504, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 603, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 498, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 3, 15, 10, 53, 635, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 11, 10, 28, 533, DateTimeKind.Utc));
        }
    }
}
