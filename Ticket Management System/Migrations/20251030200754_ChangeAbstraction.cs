using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAbstraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tickets",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tickets",
                newName: "Name");
        }
    }
}
