using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quiz_web.Server.Models
{
    public class QuizSubmission
    {
        public List<QuizAnswerSubmission> Answers { get; set; }
    }
    public class QuizAnswerSubmission
    {
        public int QuizQuestionId { get; set; }
        public string SelectedAnswer { get; set; }
        public List<string> SelectedAnswers { get; set; }

    }
    public class HighScoreRequest
    {
        public string Email { get; set; }
        public float Score { get; set; }
    }

    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string QuestionType { get; set; }

        [Required]
        public ICollection<QuizAnswer> Answers { get; set; }
    }

    public class QuizAnswer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QuizQuestion")]
        public int QuizQuestionId { get; set; }

        [Required]
        [StringLength(200)]
        public string QuizAnswers { get; set; }

        [Required]
        public bool isCorrect { get; set; }

        public QuizQuestion QuizQuestion { get; set; }


    }

    public class HighScore
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public float Score { get; set; }
        public DateTime AchievedAt { get; set; } = DateTime.UtcNow;
    }
}
