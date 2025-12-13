using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class add_EligibilityCriterias_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EligibilityCriteria",
                columns: table => new
                {
                    EligibilityCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriteria", x => x.EligibilityCriteriaId);
                    table.ForeignKey(
                        name: "FK_EligibilityCriteria_tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "tenders",
                        principalColumn: "tenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityCriteria_tenderId",
                table: "EligibilityCriteria",
                column: "tenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EligibilityCriteria");
        }
    }
}
