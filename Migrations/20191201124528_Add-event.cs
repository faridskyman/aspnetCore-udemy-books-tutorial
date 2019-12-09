using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace udemy_web_project_01.Migrations
{
    public partial class Addevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evtName = table.Column<string>(maxLength: 30, nullable: true),
                    description = table.Column<string>(maxLength: 120, nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    day1 = table.Column<bool>(nullable: false),
                    day2 = table.Column<bool>(nullable: false),
                    day3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
