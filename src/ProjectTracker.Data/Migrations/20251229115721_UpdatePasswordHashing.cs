using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XhKGdZGq7SjZ6xMxZ7B8/.TZyqH8Z8nFJZq7B8/.TZyqH8Z8nFJZq7");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJ5K8X8qF5K8X8qF5K8X8qF5K8X8qF5K8X8qF5K8X8qF5K8X8qF5K8X8qF5K8X8qF5==");
        }
    }
}
