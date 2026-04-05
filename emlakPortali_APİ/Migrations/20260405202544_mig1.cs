using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace emlakPortali_APİ.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Locations_LocationId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_LocationId",
                table: "Property",
                newName: "IX_Property_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CategoryId",
                table: "Property",
                newName: "IX_Property_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingAge",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HeatingType",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFurnished",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AdvertisementImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementImages_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementImages_AdvertisementId",
                table: "AdvertisementImages",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_AdvertisementId",
                table: "UserFavorites",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_AppUserId",
                table: "UserFavorites",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Categories_CategoryId",
                table: "Property",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Locations_LocationId",
                table: "Property",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Categories_CategoryId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Locations_LocationId",
                table: "Property");

            migrationBuilder.DropTable(
                name: "AdvertisementImages");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "BuildingAge",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "HeatingType",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "IsFurnished",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameIndex(
                name: "IX_Property_LocationId",
                table: "Properties",
                newName: "IX_Properties_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_CategoryId",
                table: "Properties",
                newName: "IX_Properties_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Locations_LocationId",
                table: "Properties",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
