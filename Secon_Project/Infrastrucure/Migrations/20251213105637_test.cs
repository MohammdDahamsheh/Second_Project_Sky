using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EligibilityCriteria_tenders_tenderId",
                table: "EligibilityCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EligibilityCriteria",
                table: "EligibilityCriteria");

            migrationBuilder.RenameTable(
                name: "EligibilityCriteria",
                newName: "EligibilityCriterias");

            migrationBuilder.RenameIndex(
                name: "IX_EligibilityCriteria_tenderId",
                table: "EligibilityCriterias",
                newName: "IX_EligibilityCriterias_tenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EligibilityCriterias",
                table: "EligibilityCriterias",
                column: "EligibilityCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibilityCriterias_tenders_tenderId",
                table: "EligibilityCriterias",
                column: "tenderId",
                principalTable: "tenders",
                principalColumn: "tenderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EligibilityCriterias_tenders_tenderId",
                table: "EligibilityCriterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EligibilityCriterias",
                table: "EligibilityCriterias");

            migrationBuilder.RenameTable(
                name: "EligibilityCriterias",
                newName: "EligibilityCriteria");

            migrationBuilder.RenameIndex(
                name: "IX_EligibilityCriterias_tenderId",
                table: "EligibilityCriteria",
                newName: "IX_EligibilityCriteria_tenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EligibilityCriteria",
                table: "EligibilityCriteria",
                column: "EligibilityCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibilityCriteria_tenders_tenderId",
                table: "EligibilityCriteria",
                column: "tenderId",
                principalTable: "tenders",
                principalColumn: "tenderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
