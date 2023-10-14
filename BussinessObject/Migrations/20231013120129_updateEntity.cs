using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Journals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Journals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Journals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Journals",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JournalsId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UsersId",
                table: "Journals",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles",
                column: "JournalsId",
                principalTable: "Journals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_UsersId",
                table: "Journals",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Journals_JournalsId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Users_UsersId",
                table: "Journals");

            migrationBuilder.DropIndex(
                name: "IX_Journals_UsersId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Journals");

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
    }
}
