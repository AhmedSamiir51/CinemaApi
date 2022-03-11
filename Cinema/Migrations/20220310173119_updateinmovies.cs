using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class updateinmovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdHalls",
                table: "Movies",
                type: "int",
                nullable: true );

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibale",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_IdHalls",
                table: "Movies",
                column: "IdHalls",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Halls_IdHalls",
                table: "Movies",
                column: "IdHalls",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Halls_IdHalls",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_IdHalls",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IdHalls",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsVisibale",
                table: "Movies");
        }
    }
}
