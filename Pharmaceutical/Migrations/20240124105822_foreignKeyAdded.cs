using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmaceutical.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserCareers_UserId",
                table: "UserCareers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCareers_Users_UserId",
                table: "UserCareers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCareers_Users_UserId",
                table: "UserCareers");

            migrationBuilder.DropIndex(
                name: "IX_UserCareers_UserId",
                table: "UserCareers");
        }
    }
}
