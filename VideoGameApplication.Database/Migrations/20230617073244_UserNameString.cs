﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApplication.Database.Migrations
{
    /// <inheritdoc />
    public partial class UserNameString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reviews");
        }
    }
}
