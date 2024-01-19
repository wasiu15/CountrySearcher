using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CountrySearcher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CountryIso = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Operator = table.Column<string>(type: "TEXT", nullable: false),
                    OperatorCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryDetails_Countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "CountryCode", "CountryIso", "Name" },
                values: new object[,]
                {
                    { 1, "234", "NG", "Nigeria" },
                    { 2, "233", "GH", "Ghana" },
                    { 3, "229", "BN", "Benin Republic" },
                    { 4, "225", "CIV", "Cote d'Ivoire" }
                });

            migrationBuilder.InsertData(
                table: "CountryDetails",
                columns: new[] { "Id", "CountryId", "Operator", "OperatorCode" },
                values: new object[,]
                {
                    { 1, 1, "MTN Nigeria", "MTN NG" },
                    { 2, 1, "Airtel Nigeria", "ANG" },
                    { 3, 1, "9 Mobile Nigeria", "ETN" },
                    { 4, 1, "Globacom Nigeria", "GLO" },
                    { 5, 2, "Vodafone Ghana", "Vodafon GH" },
                    { 6, 2, "MTN Ghana", "MTN Ghana" },
                    { 7, 2, "Tigo Ghana", "Tigo Ghana" },
                    { 8, 3, "MTN Benin", "MTN Benin" },
                    { 9, 3, "Moov Benin", "Moov Benin" },
                    { 10, 4, "MTN Cote d'Ivoire", "MTN CIV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryDetails_CountryId",
                table: "CountryDetails",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDetails");

            migrationBuilder.DropTable(
                name: "Countrys");
        }
    }
}
