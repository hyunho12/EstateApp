﻿using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() 
        {
            
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "KHH", Email = "khh@gmail.com", Password = "asdf", Phone = "010-2323-1212" },
                new User { Id = 2, Name = "Poo", Email = "poo@gmail.com", Password = "asdf", Phone = "010-4354-6543" },
                new User { Id = 3, Name = "Chu", Email = "chu@gmail.com", Password = "asdf", Phone = "010-6383-9023" },
                new User { Id = 4, Name = "HoHo", Email = "hoho@gmail.com", Password = "asdf", Phone = "010-1965-4765" },
                new User { Id = 5, Name = "InHwa", Email = "inhwa@gmail.com", Password = "asdf", Phone = "010-5834-7854" }
            };

            return Ok(users);
        }
    }
}
