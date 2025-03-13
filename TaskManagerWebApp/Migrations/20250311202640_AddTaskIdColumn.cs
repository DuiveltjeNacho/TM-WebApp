using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Tasks",
                newName: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "Number");
        }
    }
}
