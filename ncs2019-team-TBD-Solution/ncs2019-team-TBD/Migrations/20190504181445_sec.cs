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
                defaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 246, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 894, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 235, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 887, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SI",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZIP",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 231, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 885, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 228, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 882, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 248, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 896, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SI",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 894, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 246, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 887, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 235, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 885, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 231, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 882, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 228, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 4, 17, 4, 46, 896, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 4, 18, 14, 45, 248, DateTimeKind.Utc));
        }
    }
}
