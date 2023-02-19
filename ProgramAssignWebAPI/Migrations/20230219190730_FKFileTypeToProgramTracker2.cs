using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKFileTypeToProgramTracker2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProgramsTracker_FileDetails_FileIdID",
            //    table: "ProgramsTracker");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProgramsTracker_FileIdID",
            //    table: "ProgramsTracker");

            //migrationBuilder.RenameColumn(
            //    name: "FileIdID",
            //    table: "ProgramsTracker",
            //    newName: "FileId");

            migrationBuilder.AddColumn<int>(
                name: "FileDetailsID",
                table: "ProgramsTracker",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsTracker_FileDetailsID",
                table: "ProgramsTracker",
                column: "FileDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramsTracker_FileDetails_FileDetailsID",
                table: "ProgramsTracker",
                column: "FileDetailsID",
                principalTable: "FileDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProgramsTracker_FileDetails_FileDetailsID",
            //    table: "ProgramsTracker");

            migrationBuilder.DropIndex(
                name: "IX_ProgramsTracker_FileDetailsID",
                table: "ProgramsTracker");

            migrationBuilder.DropColumn(
                name: "FileDetailsID",
                table: "ProgramsTracker");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "ProgramsTracker",
                newName: "FileIdID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsTracker_FileIdID",
                table: "ProgramsTracker",
                column: "FileIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramsTracker_FileDetails_FileIdID",
                table: "ProgramsTracker",
                column: "FileIdID",
                principalTable: "FileDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
