using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {                
        public PropertiesController()
        {

        }

        [HttpGet("GetProperty")]
        public IActionResult GetProperty()
        {
            List<Property> properties = new List<Property>
            {
                new Property{Id = 1, Name = "Blue World", Detail = "two bedroom blue world", Address = "Dubai Marina", ImageUrl = "imagep7.jpg",
                    Price = 30000, IsTrending = true, CategoryId = 3, UserId = 2},
                new Property{Id = 2, Name = "Marina", Detail = "Sky global Real Estate", Address = "Dubai", ImageUrl = "imagep2.jpg", Price = 70000, IsTrending = true,
                    CategoryId = 1, UserId = 1},
                new Property{Id = 3, Name = "Palm View", Detail = "Allsopp Real Estate", Address = "Palm Tower", ImageUrl = "imagep5.jpg", Price = 75000, IsTrending = true, 
                    CategoryId = 4, UserId = 2},
                new Property{Id = 4, Name = "Avant Tower", Detail = "Three bed room apartment", Address = "Dubai Marina", ImageUrl = "imagep7.jpg", Price = 40000,
                    IsTrending = true, CategoryId = 2, UserId = 5}
            };

            return Ok(properties);
        }
    }
}
