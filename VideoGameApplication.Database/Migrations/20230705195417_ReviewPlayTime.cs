using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApplication.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReviewPlayTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PlayTimeHours",
                table: "Reviews",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayTimeHours",
                table: "Reviews");
        }
    }
}
