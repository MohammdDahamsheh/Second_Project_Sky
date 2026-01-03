using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class add_DB : Migration
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
                    PenaltiesForDelays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentScheduleAdvance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentScheduleUponMilestoneCompletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentScheduleAdvanceFinalApproval = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTerms", x => x.paymentTermsId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "technicalProposals",
                columns: table => new
                {
                    TechnicalProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    technicalProposalDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicalProposals", x => x.TechnicalProposalId);
                });

            migrationBuilder.CreateTable(
                name: "tenderCategories",
                columns: table => new
                {
                    tenderCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    typeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenderTypes", x => x.tenderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "tenders",
                columns: table => new
                {
                    tenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    issueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    closingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    budget = table.Column<double>(type: "float", nullable: false),
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
                name: "UserRoles",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
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
                    totalBidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "EligibilityCriterias",
                columns: table => new
                {
                    EligibilityCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriterias", x => x.EligibilityCriteriaId);
                    table.ForeignKey(
                        name: "FK_EligibilityCriterias_tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "tenders",
                        principalColumn: "tenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenderDocuments",
                columns: table => new
                {
                    tenderDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenderId = table.Column<int>(type: "int", nullable: false),
                    documentFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "bidDocuments",
                columns: table => new
                {
                    bidDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidId = table.Column<int>(type: "int", nullable: false),
                    technicalProposalId = table.Column<int>(type: "int", nullable: false),
                    companyRegistrationCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    taxComplianceCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    financialStatementsLast_2Years = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_bidDocuments_technicalProposals_technicalProposalId",
                        column: x => x.technicalProposalId,
                        principalTable: "technicalProposals",
                        principalColumn: "TechnicalProposalId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_bidDocuments_bidId",
                table: "bidDocuments",
                column: "bidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bidDocuments_technicalProposalId",
                table: "bidDocuments",
                column: "technicalProposalId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_declaretions_bidId",
                table: "declaretions",
                column: "bidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityCriterias_tenderId",
                table: "EligibilityCriterias",
                column: "tenderId");

            migrationBuilder.CreateIndex(
                name: "IX_financialProposals_bidDocumentId",
                table: "financialProposals",
                column: "bidDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_roleName",
                table: "Roles",
                column: "roleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenderCategories_categoryName",
                table: "tenderCategories",
                column: "categoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenderDocuments_tenderId",
                table: "tenderDocuments",
                column: "tenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderCategoryId",
                table: "tenders",
                column: "tenderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_tenderTypeId",
                table: "tenders",
                column: "tenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tenders_userId",
                table: "tenders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_tenderTypes_typeName",
                table: "tenderTypes",
                column: "typeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_roleId",
                table: "UserRoles",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
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
                name: "EligibilityCriterias");

            migrationBuilder.DropTable(
                name: "financialProposals");

            migrationBuilder.DropTable(
                name: "tenderDocuments");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "winBids");

            migrationBuilder.DropTable(
                name: "bidDocuments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "bids");

            migrationBuilder.DropTable(
                name: "technicalProposals");

            migrationBuilder.DropTable(
                name: "paymentTerms");

            migrationBuilder.DropTable(
                name: "tenders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tenderCategories");

            migrationBuilder.DropTable(
                name: "tenderTypes");
        }
    }
}
