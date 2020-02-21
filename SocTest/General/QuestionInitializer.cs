using Newtonsoft.Json;
using SocTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocTest.General
{
    public class QuestionInitializer
    {
        public static void Init(DataContext context)
        {
            if (context.Questions.Count() != 0)
            {
                return;
            }
            var questions = JsonWorker.ConverFromJsonFile<List<Question>>("SocTest.General.questions.json");
            foreach (var question in questions)
            {
                context.Add(question);
            }
            context.SaveChanges();
        }
    }
}
