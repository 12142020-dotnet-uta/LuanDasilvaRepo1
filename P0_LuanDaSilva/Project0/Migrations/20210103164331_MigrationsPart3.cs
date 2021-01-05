using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project0.Migrations
{
    public partial class MigrationsPart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloorTourLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FloorTourLines",
                columns: table => new
                {
                    FloorTourLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorTourLines", x => x.FloorTourLineID);
                });
        }
    }
}
