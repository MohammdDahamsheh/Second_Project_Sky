using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class updateDBBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bids_bidDocuments_bidDocumentId",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_bids_bidDocumentId",
                table: "bids");

            migrationBuilder.DropColumn(
                name: "bidDocumentId",
                table: "bids");

            migrationBuilder.AddColumn<int>(
                name: "bidId",
                table: "bidDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bidDocuments_bidId",
                table: "bidDocuments",
                column: "bidId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bidDocuments_bids_bidId",
                table: "bidDocuments",
                column: "bidId",
                principalTable: "bids",
                principalColumn: "bidId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bidDocuments_bids_bidId",
                table: "bidDocuments");

            migrationBuilder.DropIndex(
                name: "IX_bidDocuments_bidId",
                table: "bidDocuments");

            migrationBuilder.DropColumn(
                name: "bidId",
                table: "bidDocuments");

            migrationBuilder.AddColumn<int>(
                name: "bidDocumentId",
                table: "bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bids_bidDocumentId",
                table: "bids",
                column: "bidDocumentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_bidDocuments_bidDocumentId",
                table: "bids",
                column: "bidDocumentId",
                principalTable: "bidDocuments",
                principalColumn: "bidDocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
