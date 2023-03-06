using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEnterprise.Data.Migrations
{
    /// <inheritdoc />
    public partial class _27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CUser_RoleId",
                table: "CUser");

            migrationBuilder.CreateIndex(
                name: "IX_CUser_RoleId",
                table: "CUser",
                column: "RoleId",
                unique: true,
                filter: "[RoleId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CUser_RoleId",
                table: "CUser");

            migrationBuilder.CreateIndex(
                name: "IX_CUser_RoleId",
                table: "CUser",
                column: "RoleId");
        }
    }
}
