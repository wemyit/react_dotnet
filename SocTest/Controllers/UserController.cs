using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocTest.Models;

namespace SocTest.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("auth")]
        public IActionResult Auth([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var required_user = _dataContext.Users.Where(u => u.FirstName == user.FirstName).Where(u => u.LastName == user.LastName);
            if (required_user.Count() > 0) // it's not error, but it's wrong
            {
                HttpContext.Session.SetString("UserId", required_user.First().Id.ToString());
                return Ok(new
                {
                    required_user.FirstOrDefault().FirstName,
                    required_user.FirstOrDefault().LastName
                });
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var temp_user = user;
            temp_user.Id = Guid.NewGuid();
            _dataContext.Users.Add(temp_user);
            _dataContext.SaveChanges();
            HttpContext.Session.SetString("UserId", temp_user.Id.ToString());
            return Ok(new
            {
                temp_user.FirstName,
                temp_user.LastName
            });
        }
    }
}