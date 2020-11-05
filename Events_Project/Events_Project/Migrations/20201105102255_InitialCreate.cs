using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    EventTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<string>(nullable: false),
                    VenueName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<string>(nullable: true),
                    VenueId = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Date_Time = table.Column<DateTime>(nullable: false),
                    TicketsSold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.MusicId);
                    table.ForeignKey(
                        name: "FK_Musics_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<string>(nullable: true),
                    VenueId = table.Column<string>(nullable: true),
                    SportName = table.Column<string>(nullable: true),
                    Fixture = table.Column<string>(nullable: true),
                    Date_Time = table.Column<DateTime>(nullable: false),
                    TicketsSold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                    table.ForeignKey(
                        name: "FK_Sports_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sports_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_EventId",
                table: "Musics",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_EventId",
                table: "Sports",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_VenueId",
                table: "Sports",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
