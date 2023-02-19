using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FilesDetailsToHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileDetailsId",
                table: "ResourceManagerAssignmentsHistory",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManagerAssignmentsHistory_FileDetailsId",
                table: "ResourceManagerAssignmentsHistory",
                column: "FileDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceManagerAssignmentsHistory_FileDetails_FileDetailsId",
                table: "ResourceManagerAssignmentsHistory",
                column: "FileDetailsId",
                principalTable: "FileDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceManagerAssignmentsHistory_FileDetails_FileDetailsId",
                table: "ResourceManagerAssignmentsHistory");

            migrationBuilder.DropIndex(
                name: "IX_ResourceManagerAssignmentsHistory_FileDetailsId",
                table: "ResourceManagerAssignmentsHistory");

            migrationBuilder.DropColumn(
                name: "FileDetailsId",
                table: "ResourceManagerAssignmentsHistory");
        }
    }
}
