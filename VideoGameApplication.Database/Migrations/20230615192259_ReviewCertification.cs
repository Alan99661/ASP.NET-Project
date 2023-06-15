using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApplication.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReviewCertification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Certified",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certified",
                table: "Reviews");
        }
    }
}
