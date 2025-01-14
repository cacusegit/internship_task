using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_web.Server.Data;
using quiz_web.Server.Models;


namespace quiz_web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HighScoreController : ControllerBase
    {
        private readonly QuizDBContext _dBContext;

        public HighScoreController(QuizDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetHighScores()
        {
            var scores = await _dBContext.HighScores.OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.AchievedAt).Take(10).ToListAsync();
            return Ok(scores);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitHighScore([FromBody] HighScoreRequest highScoreRequest)
        { 
            var highScore = new HighScore
            {
                Email = highScoreRequest.Email, 
                Score = highScoreRequest.Score, 
                AchievedAt = DateTime.UtcNow 
            };

            _dBContext.HighScores.Add(highScore);
            await _dBContext.SaveChangesAsync();

            return Ok(new { Message = "High score saved successfully." });
        }
    }
}
