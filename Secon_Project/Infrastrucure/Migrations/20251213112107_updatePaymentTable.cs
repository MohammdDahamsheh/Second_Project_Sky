using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class updatePaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentScheduleAdvance",
                table: "paymentTerms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentScheduleAdvanceFinalApproval",
                table: "paymentTerms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentScheduleUponMilestoneCompletion",
                table: "paymentTerms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentScheduleAdvance",
                table: "paymentTerms");

            migrationBuilder.DropColumn(
                name: "PaymentScheduleAdvanceFinalApproval",
                table: "paymentTerms");

            migrationBuilder.DropColumn(
                name: "PaymentScheduleUponMilestoneCompletion",
                table: "paymentTerms");
        }
    }
}
