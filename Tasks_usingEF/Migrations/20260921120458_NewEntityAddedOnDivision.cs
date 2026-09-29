using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks_usingEF.Migrations
{
    /// <inheritdoc />
    public partial class NewEntityAddedOnDivision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "divisions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "divisions");
        }
    }
}
