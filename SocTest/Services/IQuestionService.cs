using SocTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocTest.Services
{
    public interface IQuestionService
    {
        List<Question> GetQuestionList();
        TestResult CheckAnswers(List<Answer> answers, out string error);
        bool SaveResult(string userId, TestResult result, out string error);
    }
}
