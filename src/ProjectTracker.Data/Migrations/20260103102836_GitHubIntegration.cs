using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class GitHubIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHubAvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitHubUsername",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitHubRepoUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GitHubTokens",
                columns: table => new
                {
                    GitHubTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EncryptedToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GitHubUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RateLimitRemaining = table.Column<int>(type: "int", nullable: false, defaultValue: 5000),
                    RateLimitResetAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitHubTokens", x => x.GitHubTokenId);
                    table.ForeignKey(
                        name: "FK_GitHubTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GitRepositories",
                columns: table => new
                {
                    GitRepositoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RepoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RepoOwner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultBranch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "main"),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastSyncAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SyncStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Pending"),
                    TotalCommits = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalBranches = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalContributors = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OpenIssues = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitRepositories", x => x.GitRepositoryId);
                    table.ForeignKey(
                        name: "FK_GitRepositories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GitCommits",
                columns: table => new
                {
                    GitCommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitRepositoryId = table.Column<int>(type: "int", nullable: false),
                    Sha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuthorEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuthorGitHubUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuthorAvatarUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CommitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Additions = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Deletions = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ChangedFilesCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LinkedTaskId = table.Column<int>(type: "int", nullable: true),
                    MatchScore = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitCommits", x => x.GitCommitId);
                    table.ForeignKey(
                        name: "FK_GitCommits_GitRepositories_GitRepositoryId",
                        column: x => x.GitRepositoryId,
                        principalTable: "GitRepositories",
                        principalColumn: "GitRepositoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GitCommits_Tasks_LinkedTaskId",
                        column: x => x.LinkedTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "GitFileChanges",
                columns: table => new
                {
                    GitFileChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitCommitId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Additions = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Deletions = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitFileChanges", x => x.GitFileChangeId);
                    table.ForeignKey(
                        name: "FK_GitFileChanges_GitCommits_GitCommitId",
                        column: x => x.GitCommitId,
                        principalTable: "GitCommits",
                        principalColumn: "GitCommitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "GitHubRepoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "GitHubRepoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "GitHubRepoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "GitHubAvatarUrl", "GitHubUsername" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_GitCommits_CommitDate",
                table: "GitCommits",
                column: "CommitDate");

            migrationBuilder.CreateIndex(
                name: "IX_GitCommits_GitRepositoryId_Sha",
                table: "GitCommits",
                columns: new[] { "GitRepositoryId", "Sha" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GitCommits_LinkedTaskId",
                table: "GitCommits",
                column: "LinkedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_GitFileChanges_FileExtension",
                table: "GitFileChanges",
                column: "FileExtension");

            migrationBuilder.CreateIndex(
                name: "IX_GitFileChanges_FileName",
                table: "GitFileChanges",
                column: "FileName");

            migrationBuilder.CreateIndex(
                name: "IX_GitFileChanges_GitCommitId",
                table: "GitFileChanges",
                column: "GitCommitId");

            migrationBuilder.CreateIndex(
                name: "IX_GitHubTokens_UserId",
                table: "GitHubTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GitRepositories_ProjectId",
                table: "GitRepositories",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitFileChanges");

            migrationBuilder.DropTable(
                name: "GitHubTokens");

            migrationBuilder.DropTable(
                name: "GitCommits");

            migrationBuilder.DropTable(
                name: "GitRepositories");

            migrationBuilder.DropColumn(
                name: "GitHubAvatarUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GitHubUsername",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GitHubRepoUrl",
                table: "Projects");
        }
    }
}
