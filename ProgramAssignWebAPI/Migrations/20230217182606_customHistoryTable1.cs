using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class customHistoryTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "FileDetails",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
        //            FileType = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FileDetails", x => x.ID);
        //        });

            migrationBuilder.CreateTable(
                name: "ResourceManagerAssignmentsHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    VAMID = table.Column<int>(type: "int", nullable: false),
                    TechTrack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMEStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramsTrackerId = table.Column<int>(type: "int", nullable: false),
                    HistoryProgramTrackerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceManagerAssignmentsHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_ResourceManagerAssignmentsHistory_ProgramsTracker_ProgramsTrackerId",
                        column: x => x.ProgramsTrackerId,
                        principalTable: "ProgramsTracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManagerAssignmentsHistory_ProgramsTrackerId",
                table: "ResourceManagerAssignmentsHistory",
                column: "ProgramsTrackerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "ResourceManagerAssignmentsHistory");
        }
    }
}
