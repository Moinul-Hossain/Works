using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackSystems.Migrations
{
    public partial class fm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Issues",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "IssueText",
                table: "Issues",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Issues",
                newName: "IssueText");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Issues",
                newName: "Status");
        }
    }
}
