using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstateWebApi.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {                
        ApiDbContext dbContext = new ApiDbContext();

        public PropertiesController()
        {

        }

        [HttpGet("GetRealPropertyList")]
        [Authorize]
        public IActionResult GetRealProperties(int categoryId) 
        {
            var propertiesResult = dbContext.RealProperties.Where(c => c.CategoryId == categoryId);
            if(propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("GetPropertyDetail")]
        [Authorize]
        public IActionResult GetPropertyDetail(int propertyId)
        {
            //var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            //var user = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);

            //if(user == null) { return NotFound(); }

            var propertyResult = dbContext.RealProperties.Find(propertyId);

            if(propertyResult !=null) 
            {
                var result = dbContext.RealProperties.Where(p => p.Id == propertyId)
                    .Select(p => new 
                    {p.Id, p.Name, p.Detail, p.Address, p.Price, p.ImageUrl, p.User.Phone}).FirstOrDefault();

                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetTrendingProperties")]
        [Authorize]
        public IActionResult GetTrendingProperties()
        {
            var propertiesResult = dbContext.RealProperties.Where(c => c.IsTrending == true);
            if(propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("GetSearchProperties")]
        [Authorize]
        public IActionResult GetSearchProperties(string address)
        {
            var propertiesResult = dbContext.RealProperties.Where(p => p.Address.Contains(address));
            if (propertiesResult == null)
            {
                return NotFound();
            }

            return Ok(propertiesResult);
        }

    }
}
