using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class testDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paymentTerms",
                columns: table => new
                {
                    paymentTermsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    termMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PenaltiesForDelays = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTerms", x => x.paymentTermsId);
                });

            migrationBuilder.CreateTable(
                name: "bids",
                columns: table => new
                {
                    bidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenderId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentTermsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bids", x => x.bidId);
                    table.ForeignKey(
                        name: "FK_bids_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bids_paymentTerms_paymentTermsId",
                        column: x => x.paymentTermsId,
                        principalTable: "paymentTerms",
                        principalColumn: "paymentTermsId");
                    table.ForeignKey(
                        name: "FK_bids_tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "tenders",
                        principalColumn: "tenderId");
                });

            migrationBuilder.CreateTable(
                name: "bidDocuments",
                columns: table => new
                {
                    bidDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidId = table.Column<int>(type: "int", nullable: false),
                    documentPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bidDocuments", x => x.bidDocumentId);
                    table.ForeignKey(
                        name: "FK_bidDocuments_bids_bidId",
                        column: x => x.bidId,
                        principalTable: "bids",
                        principalColumn: "bidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bidDocuments_bidId",
                table: "bidDocuments",
                column: "bidId");

            migrationBuilder.CreateIndex(
                name: "IX_bids_paymentTermsId",
                table: "bids",
                column: "paymentTermsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bids_tenderId",
                table: "bids",
                column: "tenderId");

            migrationBuilder.CreateIndex(
                name: "IX_bids_userId",
                table: "bids",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bidDocuments");

            migrationBuilder.DropTable(
                name: "bids");

            migrationBuilder.DropTable(
                name: "paymentTerms");
        }
    }
}
