using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizContext dbContext;

        public QuestionController(QuizContext ctx)
        {
            dbContext = ctx;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return dbContext.Questions;
            
        }

        [HttpPost]
        public void Post([FromBody] Question question)
        {
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
                
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question question)
        {
            if (id != question.Id)
                return BadRequest();
            dbContext.Entry(question).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(question);
        }

    }
}
