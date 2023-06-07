using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApplication.Database.Migrations
{
    /// <inheritdoc />
    public partial class GameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "GameWebsite",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScreenshotId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScreenshotId",
                table: "Games",
                column: "ScreenshotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Screenshots_ScreenshotId",
                table: "Games",
                column: "ScreenshotId",
                principalTable: "Screenshots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Screenshots_ScreenshotId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScreenshotId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameWebsite",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ScreenshotId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
