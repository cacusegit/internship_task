using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_web.Server.Data;
using quiz_web.Server.Models;


namespace quiz_web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizQuestionController : ControllerBase
    {
        private readonly QuizDBContext _dbContext;

        public QuizQuestionController(QuizDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _dbContext.QuizQuestion.Include(q => q.Answers).ToListAsync();
            return Ok(questions);
        }
        
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmission submission)
        {
            var allQuestions = await _dbContext.QuizQuestion.Include(q => q.Answers).ToListAsync();
            int score = 0;

            foreach (var userAnswer in submission.Answers)
            {
                var question = allQuestions.FirstOrDefault(q => q.Id == userAnswer.QuizQuestionId);
                if (question == null) continue;

                var correctAnswers = question.Answers.Where(a => a.isCorrect).Select(a => a.QuizAnswers).ToList();

                //Console.WriteLine($"Question: {question.QuestionText}");
                //Console.WriteLine($"Correct Answers: {string.Join(", ", correctAnswers)}");
                //Console.WriteLine($"Selected Answer(s): {string.Join(", ", userAnswer.SelectedAnswers)}");

                switch (question.QuestionType.ToLower())
                {
                    case "radio-button":
                        if (correctAnswers.Contains(userAnswer.SelectedAnswer))
                        {
                            score += 100;
                        }
                        break;

                    case "checkbox":
                        int correctSelections = correctAnswers.Intersect(userAnswer.SelectedAnswers).Count();
                        if (correctAnswers.Count > 0)
                        {
                            score += (int)Math.Ceiling(100.0 / correctAnswers.Count * correctSelections);
                        }
                        break;

                    case "text":
                        if (correctAnswers.Any(a => string.Equals(a, userAnswer.SelectedAnswer, StringComparison.OrdinalIgnoreCase)))
                        {
                            score += 100;
                        }
                        break;

                    default:
                        break;
                }
            }
            return Ok(new { Score = score });
        }
    }
}
