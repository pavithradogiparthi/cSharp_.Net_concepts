using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_Loading.Migrations
{
    /// <inheritdoc />
    public partial class CreateVillaandVillaNumberandseedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillaAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillaAmenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Royal villa", 20000.0 },
                    { 2, "Preminum pool villa", 30000.0 },
                    { 3, "pavithra pool villa", 50000.0 }
                });

            migrationBuilder.InsertData(
                table: "VillaAmenities",
                columns: new[] { "Id", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "private pool", 1 },
                    { 2, "Microwave", 1 },
                    { 3, "private balcony", 2 },
                    { 4, "1 king bed and 1 sofa bed", 2 },
                    { 5, "1 king bed and 1 sofa bed", 2 },
                    { 6, "1 king bed and 1 sofa bed", 3 },
                    { 7, "1 king bed and 1 premimmm bed", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaAmenities_VillaId",
                table: "VillaAmenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaAmenities");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
