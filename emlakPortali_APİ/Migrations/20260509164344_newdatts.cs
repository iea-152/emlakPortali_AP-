using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace emlakPortali_APİ.Migrations
{
    /// <inheritdoc />
    public partial class newdatts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Neighborhoods_NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.AddColumn<string>(
                name: "NeighborhoodName",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeighborhoodName",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_NeighborhoodId",
                table: "Advertisements",
                column: "NeighborhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Neighborhoods_NeighborhoodId",
                table: "Advertisements",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
