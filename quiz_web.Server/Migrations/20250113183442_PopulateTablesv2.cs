using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_web.Server.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTablesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 31,
                column: "QuizQuestionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 32,
                column: "QuizQuestionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 33,
                column: "QuizQuestionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 34,
                column: "QuizQuestionId",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 31,
                column: "QuizQuestionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 32,
                column: "QuizQuestionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 33,
                column: "QuizQuestionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 34,
                column: "QuizQuestionId",
                value: 9);
        }
    }
}
