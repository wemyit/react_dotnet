using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocTest.Models
{
    public class CheckAnswersResponse
    {
        public TestResult TestResult { get; set; }
        public string Error { get; set; }
    }
}
