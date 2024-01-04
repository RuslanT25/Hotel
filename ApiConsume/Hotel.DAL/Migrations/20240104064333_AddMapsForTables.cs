using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMapsForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Testimonials",
                newName: "Commenter name");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Testimonials",
                newName: "Updated time");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Testimonials",
                newName: "Commenter image");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Testimonials",
                newName: "Deleted time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Testimonials",
                newName: "Created time");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staffs",
                newName: "Employee name");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Staffs",
                newName: "Updated time");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Staffs",
                newName: "Deleted time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Staffs",
                newName: "Created time");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Services",
                newName: "Updated time");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Services",
                newName: "Icon image");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Services",
                newName: "Deleted time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Services",
                newName: "Created time");

            migrationBuilder.AlterColumn<string>(
                name: "Commenter name",
                table: "Testimonials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Employee name",
                table: "Staffs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated time",
                table: "Testimonials",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Deleted time",
                table: "Testimonials",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "Created time",
                table: "Testimonials",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Commenter name",
                table: "Testimonials",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Commenter image",
                table: "Testimonials",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Updated time",
                table: "Staffs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Employee name",
                table: "Staffs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Deleted time",
                table: "Staffs",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "Created time",
                table: "Staffs",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Updated time",
                table: "Services",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Icon image",
                table: "Services",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "Deleted time",
                table: "Services",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "Created time",
                table: "Services",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
