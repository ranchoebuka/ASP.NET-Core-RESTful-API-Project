using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EuropeLeagues.API.Migrations
{
    public partial class InitialMigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StadiumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stadiumCapacity = table.Column<double>(type: "float", nullable: false),
                    Honours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Country", "DateofCreation", "Group", "Name" },
                values: new object[,]
                {
                    { 1, "England", new DateTimeOffset(new DateTime(1992, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "A", "English Premier League" },
                    { 2, "Spain", new DateTimeOffset(new DateTime(1980, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "A", "Spanish La Liga" },
                    { 3, "Italy", new DateTimeOffset(new DateTime(1978, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "A", "Italian Serie A" },
                    { 4, "Germany", new DateTimeOffset(new DateTime(1980, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "B", "German Bundesliga" },
                    { 5, "Scotland", new DateTimeOffset(new DateTime(1988, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "B", "Scottish Premier League" },
                    { 6, "Portugal", new DateTimeOffset(new DateTime(1995, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "C", "Primeira Liga" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Honours", "LeagueId", "ManagerName", "Name", "StadiumName", "stadiumCapacity" },
                values: new object[,]
                {
                    { 1, null, 1, "Ole Gunnar Solskjaer", "Manchester United", "Old Trafford", 75000.0 },
                    { 2, null, 1, "Frank Lampard", "Chelsea FC", "Stamford Bridge", 40500.0 },
                    { 3, null, 1, "Pep Guardiola", "Manchester City", "City of Manchester Stadium", 56000.0 },
                    { 4, null, 2, "Zinedine Zidane", "Real Madrid", "Santiago Bernabeau", 81040.0 },
                    { 5, null, 2, "Ronald Koeman", "Barcelona", "Camp Nou", 99500.0 },
                    { 6, null, 3, "Stefano Pioli", "AC Milan", "San Siro", 81500.0 },
                    { 7, null, 3, "Andrea Pirlo", "Juventus", "Allianz Stadium", 42000.0 },
                    { 8, null, 4, "Lucien Favre", "Borussia Dortmund", "Signal Iduna Park", 81000.0 },
                    { 9, null, 5, "Neil Lennon", "Celtic FC", "Celtic Park", 61000.0 },
                    { 10, null, 6, "Filipe Celikkaya", "Sporting Lisbon", "Academia Sporting", 50000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
