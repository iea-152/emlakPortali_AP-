using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace emlakPortali_APİ.Migrations
{
    /// <inheritdoc />
    public partial class featureeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementFeature",
                columns: table => new
                {
                    AdvertisementsId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementFeature", x => new { x.AdvertisementsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_AdvertisementFeature_Advertisements_AdvertisementsId",
                        column: x => x.AdvertisementsId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Asansör" },
                    { 2, "Otopark" },
                    { 3, "Havuz" },
                    { 4, "Güvenlik" },
                    { 5, "Akıllı Ev Sistemi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementFeature_FeaturesId",
                table: "AdvertisementFeature",
                column: "FeaturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementFeature");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
