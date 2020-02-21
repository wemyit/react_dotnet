using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocTest.Models;
using SocTest.Services;

namespace SocTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        DataContext _dataContext;

        public QuestionController(IQuestionService questionService, DataContext dataContext)
        {
            _questionService = questionService;
            _dataContext = dataContext;
        }

        [HttpPost("getquest")]
        public IActionResult GetQuestions()
        {
            var questions = _questionService.GetQuestionList();
            return Ok(questions);
        }

        [HttpPost("checkanswer")]
        public IActionResult CheckAnswers([FromBody]List<Answer> answers)
        {
            var result = _questionService.CheckAnswers(answers, out string error);
            if (result==null)
            {
                return BadRequest(new CheckAnswersResponse {
                    TestResult = null,
                    Error = error
                });
            }
            var user_id = HttpContext.Session.GetString("UserId");
            if (user_id.Equals(null))
            {
                return BadRequest(new CheckAnswersResponse
                {
                    TestResult = null,
                    Error = "Session is not active"
                });
            }
            var save_result = _questionService.SaveResult(user_id,result,out string saveError);
            return Ok(new CheckAnswersResponse
            {
                TestResult = result,
                Error = save_result ? null : $"Error while saving result: {saveError}"
            });
        }

        [HttpPost("getusersresults")]
        public IActionResult GetUsersResults()
        {
            var results = new List<PrevResult>();
            var results_temp = _dataContext.UserResults.Include(u=>u.User).ToList();
            foreach(var item in results_temp)
            {
                results.Add(new PrevResult {
                    Id = item.Id.ToString(),
                    Name = $"{item.User.FirstName} {item.User.LastName}",
                    Result = item.Result
                });
            }
            return Ok(results);
        }
    }
}
