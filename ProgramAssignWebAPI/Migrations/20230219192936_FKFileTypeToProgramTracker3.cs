using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKFileTypeToProgramTracker3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramsTracker_FileDetails_FileDetailsID",
                table: "ProgramsTracker");

            migrationBuilder.DropIndex(
                name: "IX_ProgramsTracker_FileDetailsID",
                table: "ProgramsTracker");

            migrationBuilder.DropColumn(
                name: "FileDetailsID",
                table: "ProgramsTracker");

            //migrationBuilder.DropColumn(
            //    name: "FileId",
            //    table: "ProgramsTracker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.AddColumn<int>(
        //        name: "FileDetailsID",
        //        table: "ProgramsTracker",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.AddColumn<int>(
        //        name: "FileId",
        //        table: "ProgramsTracker",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramsTracker_FileDetailsID",
        //        table: "ProgramsTracker",
        //        column: "FileDetailsID");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_ProgramsTracker_FileDetails_FileDetailsID",
        //        table: "ProgramsTracker",
        //        column: "FileDetailsID",
        //        principalTable: "FileDetails",
        //        principalColumn: "ID",
        //
        //onDelete: ReferentialAction.Cascade);
        //
        //
        }
    }
}
