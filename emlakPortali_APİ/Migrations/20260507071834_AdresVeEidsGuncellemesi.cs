using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace emlakPortali_APİ.Migrations
{
    /// <inheritdoc />
    public partial class AdresVeEidsGuncellemesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Advertisements",
                newName: "TasinmazNo");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Advertisements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EIDSNumber",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EIDSVerified",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhoods_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CityId",
                table: "Advertisements",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_DistrictId",
                table: "Advertisements",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_NeighborhoodId",
                table: "Advertisements",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_DistrictId",
                table: "Neighborhoods",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Cities_CityId",
                table: "Advertisements",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Districts_DistrictId",
                table: "Advertisements",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Neighborhoods_NeighborhoodId",
                table: "Advertisements",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Cities_CityId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Districts_DistrictId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Neighborhoods_NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_CityId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_DistrictId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "EIDSNumber",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "EIDSVerified",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "TasinmazNo",
                table: "Advertisements",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Advertisements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareMeter = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFloors = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_CategoryId",
                table: "Property",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_LocationId",
                table: "Property",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
