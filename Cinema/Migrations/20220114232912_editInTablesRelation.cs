using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class editInTablesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_Cat_CatID",
                table: "Movies_Cat");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Cat_MovieID",
                table: "Movies_Cat");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MovieId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                table: "Booking");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Cat_CatID",
                table: "Movies_Cat",
                column: "CatID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MovieId",
                table: "Booking",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_Cat_CatID",
                table: "Movies_Cat");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MovieId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                table: "Booking");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Cat_CatID",
                table: "Movies_Cat",
                column: "CatID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Cat_MovieID",
                table: "Movies_Cat",
                column: "MovieID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MovieId",
                table: "Booking",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId",
                unique: true);
        }
    }
}
