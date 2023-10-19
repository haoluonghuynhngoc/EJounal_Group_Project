using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateFieds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Fields_FieldsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FieldsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FieldsId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReviewResults");

            migrationBuilder.AddColumn<int>(
                name: "FieldsId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FieldsId",
                table: "Users",
                column: "FieldsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Fields_FieldsId",
                table: "Users",
                column: "FieldsId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
