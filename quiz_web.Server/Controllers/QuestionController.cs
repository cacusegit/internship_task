using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_web.Server.Data;


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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _dbContext.QuizQuestion.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return NotFound();

            return Ok(question);
        }
    }
}
