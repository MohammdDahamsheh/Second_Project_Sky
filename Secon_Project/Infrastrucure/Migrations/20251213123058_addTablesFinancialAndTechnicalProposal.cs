using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class addTablesFinancialAndTechnicalProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "technicalProposalId",
                table: "bidDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "financialProposals",
                columns: table => new
                {
                    financialProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bidDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financialProposals", x => x.financialProposalId);
                    table.ForeignKey(
                        name: "FK_financialProposals_bidDocuments_bidDocumentId",
                        column: x => x.bidDocumentId,
                        principalTable: "bidDocuments",
                        principalColumn: "bidDocumentId");
                });

            migrationBuilder.CreateTable(
                name: "technicalProposals",
                columns: table => new
                {
                    TechnicalProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    technicalApproachDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    methodologyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proposedSolution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicalProposals", x => x.TechnicalProposalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bidDocuments_technicalProposalId",
                table: "bidDocuments",
                column: "technicalProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_financialProposals_bidDocumentId",
                table: "financialProposals",
                column: "bidDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_bidDocuments_technicalProposals_technicalProposalId",
                table: "bidDocuments",
                column: "technicalProposalId",
                principalTable: "technicalProposals",
                principalColumn: "TechnicalProposalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bidDocuments_technicalProposals_technicalProposalId",
                table: "bidDocuments");

            migrationBuilder.DropTable(
                name: "financialProposals");

            migrationBuilder.DropTable(
                name: "technicalProposals");

            migrationBuilder.DropIndex(
                name: "IX_bidDocuments_technicalProposalId",
                table: "bidDocuments");

            migrationBuilder.DropColumn(
                name: "technicalProposalId",
                table: "bidDocuments");
        }
    }
}
