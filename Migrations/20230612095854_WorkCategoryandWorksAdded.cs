using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBacktask2.Migrations
{
    /// <inheritdoc />
    public partial class WorkCategoryandWorksAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Works",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkCategoryId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkCategoryId",
                table: "Works",
                column: "WorkCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkCategories_WorkCategoryId",
                table: "Works",
                column: "WorkCategoryId",
                principalTable: "WorkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkCategories_WorkCategoryId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "WorkCategories");

            migrationBuilder.DropIndex(
                name: "IX_Works_WorkCategoryId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkCategoryId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Works",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_Works_WorkCategoryId",
                        column: x => x.WorkCategoryId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Work_WorkCategoryId",
                table: "Work",
                column: "WorkCategoryId");
        }
    }
}
