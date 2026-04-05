using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace emlakPortali_APİ.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Konut İlanları", "Konut" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Denizli" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 1, "Merkezefendi" });

            migrationBuilder.InsertData(
                table: "Neighborhoods",
                columns: new[] { "Id", "DistrictId", "Name" },
                values: new object[] { 1, 1, "Çamlaraltı" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Neighborhoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
