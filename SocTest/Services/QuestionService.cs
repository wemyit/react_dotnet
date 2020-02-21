using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocTest.General;
using SocTest.Models;

namespace SocTest.Services
{
    public class QuestionService : IQuestionService
    {
        DataContext _dataContext;

        public QuestionService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TestResult CheckAnswers(List<Answer> answers, out string error)
        {
            int RatIrrat = 0;
            int LogicsEthics = 0;
            int SensIntuit = 0;
            int ExtrvrIntrvr = 0;
            var AllQuestions = _dataContext.Questions.ToList();
            if (AllQuestions.Count != answers.Count)
            {
                error = "Answers less than questions";
                return null;
            }
            var PositiveAnswers = answers.Where(a => a.NumOfAnswer == 1).ToList();
            foreach (var item in PositiveAnswers)
            {
                var question = AllQuestions.Where(q => q.Id == item.QuestionId).First();
                switch (question.Type)
                {
                    case QuestionType.RatIrrat:
                        RatIrrat++;
                        break;
                    case QuestionType.LogicsEthics:
                        LogicsEthics++;
                        break;
                    case QuestionType.SensIntuit:
                        SensIntuit++;
                        break;
                    case QuestionType.ExtrvrIntrvr:
                        ExtrvrIntrvr++;
                        break;
                    default:
                        break;
                }
            }
            int SocTypeCode=0;
            if (RatIrrat > 8)
            {
                SocTypeCode += (LogicsEthics > 8 ? 100 : 200) + (SensIntuit > 8 ? 10 : 20);
            }
            else
            {
                SocTypeCode += (SensIntuit > 8 ? 300 : 400) + (LogicsEthics > 8 ? 10 : 20);
            }
            SocTypeCode += ExtrvrIntrvr > 8 ? 1 : 2;
            var TypesInfo = JsonWorker.ConverFromJsonFile<SocTypes>("SocTest.General.typeinfo.json");
            TypesInfo.AboutTypes.TryGetValue(SocTypeCode, out string AboutType);
            TypesInfo.TypesName.TryGetValue(SocTypeCode, out string SocType);
            var result = new TestResult
                {
                    SocType = SocType,
                    AboutType = AboutType
                };
            error = null;
            return result;
        }

        public bool SaveResult(string userId, TestResult result, out string error)
        {
            var user = _dataContext.Users.Where(u => u.Id == Guid.Parse(userId)).FirstOrDefault();
            if (user.Equals(null))
            {
                error = "User not found";
                return false;
            }
            var user_result = new UserResults
            {
                User = user,
                Result = result.SocType
            };
            _dataContext.UserResults.Add(user_result);
            try
            {
                _dataContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                error = ex.Message;
                return false;
            }
            error = null;
            return true;
        }

        public List<Question> GetQuestionList()
        {
            return _dataContext.Questions.OrderBy(q=>Guid.NewGuid()).ToList();
        }
    }
}
