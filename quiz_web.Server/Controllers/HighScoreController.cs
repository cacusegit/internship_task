using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_web.Server.Data;
using quiz_web.Server.Models;


namespace quiz_web.Server.Controllers
{
    [ApiController]
    [Route("api/controller")]
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
                .ThenByDescending(x => x.AchievedAt).ToListAsync();
            return Ok(scores);
        }

        [HttpPost]
        public async Task<IActionResult> AddHighScore([FromBody] HighScore highscore)
        {
            highscore.AchievedAt = DateTime.UtcNow;

            _dBContext.HighScores.Add(highscore);
            await _dBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHighScores), new { id = highscore.Id }, highscore);
        }
    }
}
