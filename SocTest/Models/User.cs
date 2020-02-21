using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocTest.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name must be setted")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name is too short/long")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name must be setted")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name is too short/long")]
        public string LastName { get; set; }
    }
}
