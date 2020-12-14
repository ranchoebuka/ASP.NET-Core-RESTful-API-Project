using Microsoft.EntityFrameworkCore.Migrations;

namespace EuropeLeagues.API.Migrations
{
    public partial class addedGroupCatergory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "stadiumCapacity",
                table: "Clubs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ManagerName", "stadiumCapacity" },
                values: new object[] { "Ole Gunnar Solskjaer", 75000.0 });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "stadiumCapacity",
                value: 40500.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "stadiumCapacity",
                value: 56000.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "stadiumCapacity",
                value: 81040.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "stadiumCapacity",
                value: 99500.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "stadiumCapacity",
                value: 81500.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 7,
                column: "stadiumCapacity",
                value: 42000.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 8,
                column: "stadiumCapacity",
                value: 81000.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 9,
                column: "stadiumCapacity",
                value: 61000.0);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 10,
                column: "stadiumCapacity",
                value: 50000.0);

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                column: "Group",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                column: "Group",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                column: "Group",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 4,
                column: "Group",
                value: "B");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 5,
                column: "Group",
                value: "B");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 6,
                column: "Group",
                value: "C");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "stadiumCapacity",
                table: "Clubs");

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManagerName",
                value: "Ole Solskjear");
        }
    }
}
