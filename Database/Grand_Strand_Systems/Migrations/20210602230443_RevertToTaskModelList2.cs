using Microsoft.EntityFrameworkCore.Migrations;

namespace Grand_Strand_Systems.Migrations
{
    public partial class RevertToTaskModelList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskModel_Contacts_ContactModelID",
                table: "TaskModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskModel",
                table: "TaskModel");

            migrationBuilder.DropIndex(
                name: "IX_TaskModel_ContactModelID",
                table: "TaskModel");

            migrationBuilder.DropColumn(
                name: "ContactModelID",
                table: "TaskModel");

            migrationBuilder.RenameTable(
                name: "TaskModel",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ContactID",
                table: "Tasks",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ContactID",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskModel");

            migrationBuilder.AddColumn<string>(
                name: "ContactModelID",
                table: "TaskModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskModel",
                table: "TaskModel",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_ContactModelID",
                table: "TaskModel",
                column: "ContactModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModel_Contacts_ContactModelID",
                table: "TaskModel",
                column: "ContactModelID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
