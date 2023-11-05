using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBacktask2.Migrations
{
    /// <inheritdoc />
    public partial class AboutIntroComponentsIsDeletedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AboutIntroComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AboutIntroComponents");
        }
    }
}
