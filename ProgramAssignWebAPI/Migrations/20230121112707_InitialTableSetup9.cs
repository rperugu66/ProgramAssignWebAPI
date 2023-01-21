using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramAssignWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialTableSetup9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ResourceMangerAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VAMID = table.Column<int>(type: "int", nullable: false),
                    TechTrack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMEStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramsTrackerId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ResourceMangerAssignments_ProgramsTrackerId",
                table: "ResourceMangerAssignments",
                column: "ProgramsTrackerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceMangerAssignments");

            migrationBuilder.DropTable(
                name: "ProgramsTracker");
        }
    }
}
