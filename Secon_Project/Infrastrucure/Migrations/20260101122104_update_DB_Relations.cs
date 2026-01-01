using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class update_DB_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tenders_tenderCategoryId",
                table: "tenders");

            migrationBuilder.DropIndex(
                name: "IX_tenders_tenderTypeId",
                table: "tenders");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderCategoryId",
                table: "tenders",
                column: "tenderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderTypeId",
                table: "tenders",
                column: "tenderTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tenders_tenderCategoryId",
                table: "tenders");

            migrationBuilder.DropIndex(
                name: "IX_tenders_tenderTypeId",
                table: "tenders");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderCategoryId",
                table: "tenders",
                column: "tenderCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderTypeId",
                table: "tenders",
                column: "tenderTypeId",
                unique: true);
        }
    }
}
