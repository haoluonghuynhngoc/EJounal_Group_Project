using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "ArticlesRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesRatings_UsersId",
                table: "ArticlesRatings",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesRatings_Users_UsersId",
                table: "ArticlesRatings",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesRatings_Users_UsersId",
                table: "ArticlesRatings");

            migrationBuilder.DropIndex(
                name: "IX_ArticlesRatings_UsersId",
                table: "ArticlesRatings");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ArticlesRatings");
        }
    }
}
