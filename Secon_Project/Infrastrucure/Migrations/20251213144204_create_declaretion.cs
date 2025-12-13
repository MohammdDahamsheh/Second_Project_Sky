using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class create_declaretion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_declaretions_bidId",
                table: "declaretions",
                column: "bidId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "declaretions");
        }
    }
}
