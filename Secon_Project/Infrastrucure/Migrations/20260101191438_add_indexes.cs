using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class add_indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "typeName",
                table: "tenderTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "categoryName",
                table: "tenderCategories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "roleName",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tenderTypes_typeName",
                table: "tenderTypes",
                column: "typeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenderCategories_categoryName",
                table: "tenderCategories",
                column: "categoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_roleName",
                table: "Roles",
                column: "roleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tenderTypes_typeName",
                table: "tenderTypes");

            migrationBuilder.DropIndex(
                name: "IX_tenderCategories_categoryName",
                table: "tenderCategories");

            migrationBuilder.DropIndex(
                name: "IX_Roles_roleName",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "typeName",
                table: "tenderTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "categoryName",
                table: "tenderCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "roleName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
