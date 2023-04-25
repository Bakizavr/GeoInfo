using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GeoInfo.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AsciiName = table.Column<string>(type: "text", nullable: true),
                    AlternateName = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    FeatureClass = table.Column<string>(type: "text", nullable: true),
                    FeatureCode = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Cc2 = table.Column<string>(type: "text", nullable: true),
                    Admin1Code = table.Column<string>(type: "text", nullable: true),
                    Admin2Code = table.Column<string>(type: "text", nullable: true),
                    Admin3Code = table.Column<string>(type: "text", nullable: true),
                    Admin4Code = table.Column<string>(type: "text", nullable: true),
                    Population = table.Column<string>(type: "text", nullable: true),
                    Elevation = table.Column<string>(type: "text", nullable: true),
                    Dem = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    ModificationDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
