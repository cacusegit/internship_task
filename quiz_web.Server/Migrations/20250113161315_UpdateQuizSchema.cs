using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_web.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuizSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAnswer_QuizEntries_QuizEntryId",
                table: "QuizAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAnswer_QuizQuestion_QuestionId",
                table: "QuizAnswer");

            migrationBuilder.DropTable(
                name: "QuizEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAnswer",
                table: "QuizAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuizAnswer_QuestionId",
                table: "QuizAnswer");

            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "QuizAnswer");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "QuizAnswer");

            migrationBuilder.RenameTable(
                name: "QuizAnswer",
                newName: "QuizAnswers");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "QuizAnswers",
                newName: "isCorrect");

            migrationBuilder.RenameColumn(
                name: "QuizEntryId",
                table: "QuizAnswers",
                newName: "QuizQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAnswer_QuizEntryId",
                table: "QuizAnswers",
                newName: "IX_QuizAnswers_QuizQuestionId");

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "QuizQuestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HighScores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "QuizAnswers",
                table: "QuizAnswers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAnswers_QuizQuestion_QuizQuestionId",
                table: "QuizAnswers",
                column: "QuizQuestionId",
                principalTable: "QuizQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAnswers_QuizQuestion_QuizQuestionId",
                table: "QuizAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "QuizAnswers",
                table: "QuizAnswers");

            migrationBuilder.RenameTable(
                name: "QuizAnswers",
                newName: "QuizAnswer");

            migrationBuilder.RenameColumn(
                name: "isCorrect",
                table: "QuizAnswer",
                newName: "IsCorrect");

            migrationBuilder.RenameColumn(
                name: "QuizQuestionId",
                table: "QuizAnswer",
                newName: "QuizEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAnswers_QuizQuestionId",
                table: "QuizAnswer",
                newName: "IX_QuizAnswer_QuizEntryId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HighScores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "QuizAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "QuizAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAnswer",
                table: "QuizAnswer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizEntries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswer_QuestionId",
                table: "QuizAnswer",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAnswer_QuizEntries_QuizEntryId",
                table: "QuizAnswer",
                column: "QuizEntryId",
                principalTable: "QuizEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAnswer_QuizQuestion_QuestionId",
                table: "QuizAnswer",
                column: "QuestionId",
                principalTable: "QuizQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
