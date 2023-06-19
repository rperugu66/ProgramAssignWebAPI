using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VAMID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsTracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechTrack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsTracker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechTrack = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VAMId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

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
                    HistoryProgramTrackerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMEComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetailsId = table.Column<int>(type: "int", nullable: true),
                    AssociateSubmittedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    AssociateDelayDays = table.Column<int>(type: "int", nullable: true),
                    SMEStartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    SMEEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    SMEApprovedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    SMEDelayDays = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ResourceMangerAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    SMEComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramsTrackerId = table.Column<int>(type: "int", nullable: false),
                    HistoryProgramTrackerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceMangerAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceMangerAssignments_ProgramsTracker_ProgramsTrackerId",
                        column: x => x.ProgramsTrackerId,
                        principalTable: "ProgramsTracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManagerAssignmentsHistory_ProgramsTrackerId",
                table: "ResourceManagerAssignmentsHistory",
                column: "ProgramsTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceMangerAssignments_ProgramsTrackerId",
                table: "ResourceMangerAssignments",
                column: "ProgramsTrackerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "ResourceManagerAssignmentsHistory");

            migrationBuilder.DropTable(
                name: "ResourceMangerAssignments");

            migrationBuilder.DropTable(
                name: "TechTracks");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "ProgramsTracker");
        }
    }
}
