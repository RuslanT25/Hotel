using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityToAllEntityClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Testimonials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Subscribes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Subscribes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Subscribes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Rooms");
        }
    }
}
