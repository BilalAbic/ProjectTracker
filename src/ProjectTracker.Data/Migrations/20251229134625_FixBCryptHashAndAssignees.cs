using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixBCryptHashAndAssignees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "AssignedUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "AssignedUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "AssignedUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "AssignedUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XhKGdZGq7SjZ6xMxZ7B8/.TZyqH8Z8nFJZq7B8/.TZyqH8Z8nFJZq7");
        }
    }
}
