using Microsoft.EntityFrameworkCore.Migrations;

namespace Grand_Strand_Systems.Migrations
{
    public partial class AddTaskViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Contacts_ContactModelID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ContactModelID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ContactModelID",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactModelID",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ContactModelID",
                table: "Tasks",
                column: "ContactModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Contacts_ContactModelID",
                table: "Tasks",
                column: "ContactModelID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
