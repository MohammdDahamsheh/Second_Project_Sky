using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class add_winBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalBidAmount",
                table: "bids",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "declaretions",
                columns: table => new
                {
                    declaretionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    declarationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_declaretions", x => x.declaretionId);
                    table.ForeignKey(
                        name: "FK_declaretions_bids_bidId",
                        column: x => x.bidId,
                        principalTable: "bids",
                        principalColumn: "bidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "winBids",
                columns: table => new
                {
                    winBidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidId = table.Column<int>(type: "int", nullable: false),
                    awardedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    tenderId = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_winBids", x => x.winBidId);
                    table.ForeignKey(
                        name: "FK_winBids_bids_bidId",
                        column: x => x.bidId,
                        principalTable: "bids",
                        principalColumn: "bidId");
                    table.ForeignKey(
                        name: "FK_winBids_tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "tenders",
                        principalColumn: "tenderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_declaretions_bidId",
                table: "declaretions",
                column: "bidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_winBids_bidId",
                table: "winBids",
                column: "bidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_winBids_tenderId",
                table: "winBids",
                column: "tenderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "declaretions");

            migrationBuilder.DropTable(
                name: "winBids");

            migrationBuilder.DropColumn(
                name: "totalBidAmount",
                table: "bids");
        }
    }
}
