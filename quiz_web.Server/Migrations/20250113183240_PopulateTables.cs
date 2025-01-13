using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quiz_web.Server.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuizQuestion",
                columns: new[] { "Id", "QuestionText", "QuestionType" },
                values: new object[,]
                {
                    { 1, "Arthas Menethil was the prince of which kingdom in World of Warcraft?", "radio-button" },
                    { 2, "Which raid instance is located in Stranglethorn Vale in World of Warcraft?", "radio-button" },
                    { 3, "The entrance to Blackwing Lair raid is found inside what instance in World of Warcraft?", "radio-button" },
                    { 4, "Who is the current Warchief of the Horde?", "radio-button" },
                    { 5, "What is the name of the human capital city in World of Warcraft?", "text" },
                    { 6, "Which four-wing instance located in Tirisfal Glades is frequently farmed by players in World of Warcraft?", "text" },
                    { 7, "In which of these zones can you find the dwarwen hunter Hemet Nesigwary?", "checkbox" },
                    { 8, "Which of these are the original Four Horsemen found in Naxxramas?", "checkbox" },
                    { 9, "Which of these professions are of the secondary type?", "checkbox" },
                    { 10, "Which of these bosses can you find in the raid Black Temple?", "checkbox" }
                });

            migrationBuilder.InsertData(
                table: "QuizAnswers",
                columns: new[] { "Id", "QuizAnswers", "QuizQuestionId", "isCorrect" },
                values: new object[,]
                {
                    { 1, "Stormwind", 1, false },
                    { 2, "Lordaeron", 1, true },
                    { 3, "Gilneas", 1, false },
                    { 4, "Quel'Thalas", 1, false },
                    { 5, "Zul'Gurub", 2, true },
                    { 6, "Icecrown Citadel", 2, false },
                    { 7, "The Nighthold", 2, false },
                    { 8, "Chambers of Xeric", 2, false },
                    { 9, "Gnomeregan", 3, false },
                    { 10, "Blackrock Spire", 3, true },
                    { 11, "Blackrock Depths", 3, false },
                    { 12, "The Black Morass", 3, false },
                    { 13, "Garrosh Hellscream", 4, false },
                    { 14, "Sylvannas Windrunner", 4, false },
                    { 15, "Vol'jin", 4, false },
                    { 16, "None of the above", 4, false },
                    { 17, "Stormwind", 5, true },
                    { 18, "Scarlet Monestary", 6, true },
                    { 19, "Stranglethorn Vale", 7, true },
                    { 20, "Durotar", 7, false },
                    { 21, "Tanaris", 7, false },
                    { 22, "Sholazar Basin", 7, true },
                    { 23, "Thane Korth'azz", 8, true },
                    { 24, "Lady Blaumeux", 8, true },
                    { 25, "Baron Rivendare", 8, false },
                    { 26, "Sir Zeliek", 8, true },
                    { 27, "Mining", 9, false },
                    { 28, "Blacksmithing", 9, false },
                    { 29, "First Aid", 9, true },
                    { 30, "Fishing", 9, true },
                    { 31, "Shade of Akama", 9, true },
                    { 32, "Reliquary of Souls", 9, true },
                    { 33, "Illidan Stormrage", 9, true },
                    { 34, "Mother Shahraz", 9, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "QuizAnswers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuizQuestion",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
