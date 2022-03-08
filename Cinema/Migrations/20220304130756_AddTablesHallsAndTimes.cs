using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class AddTablesHallsAndTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallsId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimerId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HallsId",
                table: "Booking",
                column: "HallsId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TimerId",
                table: "Booking",
                column: "TimerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Halls_HallsId",
                table: "Booking",
                column: "HallsId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Times_TimerId",
                table: "Booking",
                column: "TimerId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Halls_HallsId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Times_TimerId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropIndex(
                name: "IX_Booking_HallsId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TimerId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "HallsId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TimerId",
                table: "Booking");
        }
    }
}
