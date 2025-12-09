using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class create_DB_for_tenderSide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tenderCategories",
                columns: table => new
                {
                    tenderCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderCategories", x => x.tenderCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tenderTypes",
                columns: table => new
                {
                    tenderTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderTypes", x => x.tenderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tenders",
                columns: table => new
                {
                    tenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    issueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    closingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    tenderTypeId = table.Column<int>(type: "int", nullable: false),
                    tenderCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenders", x => x.tenderId);
                    table.ForeignKey(
                        name: "FK_tenders_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenders_tenderCategories_tenderCategoryId",
                        column: x => x.tenderCategoryId,
                        principalTable: "tenderCategories",
                        principalColumn: "tenderCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenders_tenderTypes_tenderTypeId",
                        column: x => x.tenderTypeId,
                        principalTable: "tenderTypes",
                        principalColumn: "tenderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenderDocuments",
                columns: table => new
                {
                    tenderDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenderId = table.Column<int>(type: "int", nullable: false),
                    documentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderDocuments", x => x.tenderDocumentId);
                    table.ForeignKey(
                        name: "FK_tenderDocuments_tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "tenders",
                        principalColumn: "tenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_userId",
                table: "Users",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenderDocuments_tenderId",
                table: "tenderDocuments",
                column: "tenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_tenders_userId",
                table: "tenders",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenderDocuments");

            migrationBuilder.DropTable(
                name: "tenders");

            migrationBuilder.DropTable(
                name: "tenderCategories");

            migrationBuilder.DropTable(
                name: "tenderTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_userId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
