using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocTest.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        [Required]
        public QuestionType Type { get; set; }
    }

    public enum QuestionType
    {
        RatIrrat=1,
        LogicsEthics,
        SensIntuit,
        ExtrvrIntrvr
    }
}