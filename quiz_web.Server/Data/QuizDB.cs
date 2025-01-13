using Microsoft.EntityFrameworkCore;
using quiz_web.Server.Models;


namespace quiz_web.Server.Data
{
    public class QuizDBContext : DbContext
    {
        public DbSet<QuizQuestion> QuizQuestion { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<HighScore> HighScores { get; set; }
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<QuizAnswer>().HasOne(q => q.QuizQuestion)
            //    .WithMany(q => q.Answers).HasForeignKey(q => q.QuizQuestionId);

            modelBuilder.Entity<QuizQuestion>().HasData(
                new QuizQuestion { Id = 1, QuestionText = "Arthas Menethil was the prince of which kingdom in World of Warcraft?", QuestionType = "radio-button" },
                new QuizQuestion { Id = 2, QuestionText = "Which raid instance is located in Stranglethorn Vale in World of Warcraft?", QuestionType = "radio-button" },
                new QuizQuestion { Id = 3, QuestionText = "The entrance to Blackwing Lair raid is found inside what instance in World of Warcraft?", QuestionType = "radio-button" },
                new QuizQuestion { Id = 4, QuestionText = "Who is the current Warchief of the Horde?", QuestionType = "radio-button" },
                new QuizQuestion { Id = 5, QuestionText = "What is the name of the human capital city in World of Warcraft?", QuestionType = "text" },
                new QuizQuestion { Id = 6, QuestionText = "Which four-wing instance located in Tirisfal Glades is frequently farmed by players in World of Warcraft?", QuestionType = "text" },
                new QuizQuestion { Id = 7, QuestionText = "In which of these zones can you find the dwarwen hunter Hemet Nesigwary?", QuestionType = "checkbox" },
                new QuizQuestion { Id = 8, QuestionText = "Which of these are the original Four Horsemen found in Naxxramas?", QuestionType = "checkbox" },
                new QuizQuestion { Id = 9, QuestionText = "Which of these professions are of the secondary type?", QuestionType = "checkbox" },
                new QuizQuestion { Id = 10, QuestionText = "Which of these bosses can you find in the raid Black Temple?", QuestionType = "checkbox" }
            );

            modelBuilder.Entity<QuizAnswer>().HasData(
                new QuizAnswer { Id = 1, QuizQuestionId = 1, QuizAnswers = "Stormwind", isCorrect = false },
                new QuizAnswer { Id = 2, QuizQuestionId = 1, QuizAnswers = "Lordaeron", isCorrect = true },
                new QuizAnswer { Id = 3, QuizQuestionId = 1, QuizAnswers = "Gilneas", isCorrect = false },
                new QuizAnswer { Id = 4, QuizQuestionId = 1, QuizAnswers = "Quel'Thalas", isCorrect = false },

                new QuizAnswer { Id = 5, QuizQuestionId = 2, QuizAnswers = "Zul'Gurub", isCorrect = true },
                new QuizAnswer { Id = 6, QuizQuestionId = 2, QuizAnswers = "Icecrown Citadel", isCorrect = false },
                new QuizAnswer { Id = 7, QuizQuestionId = 2, QuizAnswers = "The Nighthold", isCorrect = false },
                new QuizAnswer { Id = 8, QuizQuestionId = 2, QuizAnswers = "Chambers of Xeric", isCorrect = false },

                new QuizAnswer { Id = 9, QuizQuestionId = 3, QuizAnswers = "Gnomeregan", isCorrect = false },
                new QuizAnswer { Id = 10, QuizQuestionId = 3, QuizAnswers = "Blackrock Spire", isCorrect = true },
                new QuizAnswer { Id = 11, QuizQuestionId = 3, QuizAnswers = "Blackrock Depths", isCorrect = false },
                new QuizAnswer { Id = 12, QuizQuestionId = 3, QuizAnswers = "The Black Morass", isCorrect = false },

                new QuizAnswer { Id = 13, QuizQuestionId = 4, QuizAnswers = "Garrosh Hellscream", isCorrect = false },
                new QuizAnswer { Id = 14, QuizQuestionId = 4, QuizAnswers = "Sylvannas Windrunner", isCorrect = false },
                new QuizAnswer { Id = 15, QuizQuestionId = 4, QuizAnswers = "Vol'jin", isCorrect = false },
                new QuizAnswer { Id = 16, QuizQuestionId = 4, QuizAnswers = "None of the above", isCorrect = false },

                new QuizAnswer { Id = 17, QuizQuestionId = 5, QuizAnswers = "Stormwind", isCorrect = true },

                new QuizAnswer { Id = 18, QuizQuestionId = 6, QuizAnswers = "Scarlet Monestary", isCorrect = true },

                new QuizAnswer { Id = 19, QuizQuestionId = 7, QuizAnswers = "Stranglethorn Vale", isCorrect = true },
                new QuizAnswer { Id = 20, QuizQuestionId = 7, QuizAnswers = "Durotar", isCorrect = false },
                new QuizAnswer { Id = 21, QuizQuestionId = 7, QuizAnswers = "Tanaris", isCorrect = false },
                new QuizAnswer { Id = 22, QuizQuestionId = 7, QuizAnswers = "Sholazar Basin", isCorrect = true },

                new QuizAnswer { Id = 23, QuizQuestionId = 8, QuizAnswers = "Thane Korth'azz", isCorrect = true },
                new QuizAnswer { Id = 24, QuizQuestionId = 8, QuizAnswers = "Lady Blaumeux", isCorrect = true },
                new QuizAnswer { Id = 25, QuizQuestionId = 8, QuizAnswers = "Baron Rivendare", isCorrect = false },
                new QuizAnswer { Id = 26, QuizQuestionId = 8, QuizAnswers = "Sir Zeliek", isCorrect = true },

                new QuizAnswer { Id = 27, QuizQuestionId = 9, QuizAnswers = "Mining", isCorrect = false },
                new QuizAnswer { Id = 28, QuizQuestionId = 9, QuizAnswers = "Blacksmithing", isCorrect = false },
                new QuizAnswer { Id = 29, QuizQuestionId = 9, QuizAnswers = "First Aid", isCorrect = true },
                new QuizAnswer { Id = 30, QuizQuestionId = 9, QuizAnswers = "Fishing", isCorrect = true },

                new QuizAnswer { Id = 31, QuizQuestionId = 10, QuizAnswers = "Shade of Akama", isCorrect = true },
                new QuizAnswer { Id = 32, QuizQuestionId = 10, QuizAnswers = "Reliquary of Souls", isCorrect = true },
                new QuizAnswer { Id = 33, QuizQuestionId = 10, QuizAnswers = "Illidan Stormrage", isCorrect = true },
                new QuizAnswer { Id = 34, QuizQuestionId = 10, QuizAnswers = "Mother Shahraz", isCorrect = true }
            );
        }
    }
}
