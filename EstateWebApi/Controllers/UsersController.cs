using EstateWebApi.Data;
using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApiDbContext dbContext = new ApiDbContext();

        private IConfiguration configuration;

        public UsersController(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        [HttpGet("[action]")]
        //[HttpGet("GetUser")]
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

        [HttpPost("[action]")]
        public IActionResult Register(User user)
        {
            var userExists = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if(userExists != null)
            {
                return BadRequest("동일한 이메일의 기존사용자가 존재합니다.");
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("[action]")]
        public IActionResult Login(Login user)
        {
            var currentUser = dbContext.Users.FirstOrDefault(u=> u.Email == user.Email && u.Password == user.Password);
            if(currentUser == null) 
            {
                return NotFound();
            }


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            // token 생성
            var token = new JwtSecurityToken(
                //issuer: configuration["JWT:Issuer"],
                //audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: credentials
                );

            // tokenHandler에 토큰을 write함
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ObjectResult(
                new
                {
                    access_token = jwt,
                    token_type = "Bearer",
                    user_id = currentUser.Id,
                    user_name = currentUser.Name
                });            
        }
    }
}
