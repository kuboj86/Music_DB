using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Album = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SongLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
