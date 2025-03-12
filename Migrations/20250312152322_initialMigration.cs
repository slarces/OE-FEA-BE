using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flag_Explorer_App.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommonName = table.Column<string>(type: "TEXT", nullable: false),
                    OfficialName = table.Column<string>(type: "TEXT", nullable: false),
                    Alpha2Code = table.Column<string>(type: "TEXT", nullable: false),
                    Alpha3Code = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryFlag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryDetailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FlagCode = table.Column<string>(type: "TEXT", nullable: false),
                    Png = table.Column<string>(type: "TEXT", nullable: false),
                    Svg = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryFlag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryFlag_CountryDetail_CountryDetailId",
                        column: x => x.CountryDetailId,
                        principalTable: "CountryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryDetailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    SubRegion = table.Column<string>(type: "TEXT", nullable: false),
                    Capital = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLocations_CountryDetail_CountryDetailId",
                        column: x => x.CountryDetailId,
                        principalTable: "CountryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryLocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GoogleMaps = table.Column<string>(type: "TEXT", nullable: false),
                    OpenStreetMaps = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_CountryLocations_CountryLocationId",
                        column: x => x.CountryLocationId,
                        principalTable: "CountryLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryFlag_CountryDetailId",
                table: "CountryFlag",
                column: "CountryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocations_CountryDetailId",
                table: "CountryLocations",
                column: "CountryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_CountryLocationId",
                table: "Maps",
                column: "CountryLocationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryFlag");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "CountryLocations");

            migrationBuilder.DropTable(
                name: "CountryDetail");
        }
    }
}
