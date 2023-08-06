using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstateWebApi.Data;
using EstateV1App.Models;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {                
        public PropertiesController()
        {

        }

        [HttpGet("GetRealProperty")]
        public IActionResult GetRealProperty()
        {
            List<RealProperty> properties = new List<RealProperty>
            {
                new RealProperty{Id = 1, Name = "Blue World", Detail = "two bedroom blue world", Address = "Dubai Marina", ImageUrl = "imagep7.jpg",
                    Price = 30000, IsTrending = true, CategoryId = 3, UserId = 2},
                new RealProperty{Id = 2, Name = "Marina", Detail = "Sky global Real Estate", Address = "Dubai", ImageUrl = "imagep2.jpg", Price = 70000, IsTrending = true,
                    CategoryId = 1, UserId = 1},
                new RealProperty{Id = 3, Name = "Palm View", Detail = "Allsopp Real Estate", Address = "Palm Tower", ImageUrl = "imagep5.jpg", Price = 75000, IsTrending = true, 
                    CategoryId = 4, UserId = 2},
                new RealProperty{Id = 4, Name = "Avant Tower", Detail = "Three bed room apartment", Address = "Dubai Marina", ImageUrl = "imagep7.jpg", Price = 40000,
                    IsTrending = true, CategoryId = 2, UserId = 5}
            };

            return Ok(properties);
        }

        [HttpGet("GetRealPropertyList")]
        public IActionResult GetPropertiesList(int categoryId)
        {            
            List<RealProperty> properties = new List<RealProperty>();            

            if(categoryId == 1)
            {
                properties = new List<RealProperty>
                {                
                    new RealProperty{Id = 2, Name = "Marina", Detail = "Sky global Real Estate", Address = "Dubai", ImageUrl = "imagep2.jpg", Price = 70000, IsTrending = true,
                        CategoryId = 1, UserId = 1}              
                };
            }
            else if( categoryId == 2)
            {
                properties = new List<RealProperty>
                {                
                    new RealProperty{Id = 4, Name = "Avant Tower", Detail = "Three bed room apartment", Address = "Dubai Marina", ImageUrl = "imagep7.jpg", Price = 40000,
                        IsTrending = true, CategoryId = 2, UserId = 5}
                };
            }
            else if(categoryId == 3)
            {
                properties = new List<RealProperty>
                {
                    new RealProperty{Id = 1, Name = "Blue World", Detail = "two bedroom blue world", Address = "Dubai Marina", ImageUrl = "imagep7.jpg",
                        Price = 30000, IsTrending = true, CategoryId = 3, UserId = 2},                
                };
            }
            else if(categoryId == 4)
            {
                properties = new List<RealProperty>
                {
                    new RealProperty{Id = 3, Name = "Palm View", Detail = "Allsopp Real Estate", Address = "Palm Tower", ImageUrl = "imagep5.jpg", Price = 75000, IsTrending = true,
                        CategoryId = 4, UserId = 2},                
                };
            }            

            return Ok(properties);
        }

        [HttpGet("GetRealPropertyDetail")]
        public IActionResult GetRealPropertyDetail(int propertyId)
        {
            List<PropertyDetail> properties = new List<PropertyDetail>();

            if (propertyId == 1)
            {
                properties = new List<PropertyDetail>
                {
                    new PropertyDetail{Id = 2, Name = "Marina", Detail = "Sky global Real Estate", Address = "Dubai", Price = 70000, ImageUrl = "imagep2.jpg",  
                         Phone = "010-5545-6985"}
                };
            }
            else if (propertyId == 2)
            {
                properties = new List<PropertyDetail>
                {
                    new PropertyDetail{Id = 4, Name = "Avant Tower", Detail = "Three bed room apartment", Address = "Dubai Marina", Price = 40000, ImageUrl = "imagep7.jpg", 
                        Phone = "010-4587-2685"}
                };
            }
            else if (propertyId == 3)
            {
                properties = new List<PropertyDetail>
                {
                    new PropertyDetail{Id = 1, Name = "Blue World", Detail = "two bedroom blue world", Address = "Dubai Marina", Price = 30000, ImageUrl = "imagep7.jpg",
                         Phone = "010-2335-5543"}
                };
            }
            else if (propertyId == 4)
            {
                properties = new List<PropertyDetail>
                {
                    new PropertyDetail{Id = 3, Name = "Palm View", Detail = "Allsopp Real Estate", Address = "Palm Tower", Price = 75000, ImageUrl = "imagep5.jpg",  
                        Phone = "010-4529-8569"}
                };
            }

            return Ok(properties);
        }
    }
}
