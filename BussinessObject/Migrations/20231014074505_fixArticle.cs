using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class fixArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "JournalsIds",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "JournalsId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles",
                column: "JournalsId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "JournalsId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JournalsIds",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles",
                column: "JournalsId",
                principalTable: "Journals",
                principalColumn: "Id");
        }
    }
}
