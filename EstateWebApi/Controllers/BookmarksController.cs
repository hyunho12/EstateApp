using EstateWebApi.Data;
using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        ApiDbContext dbContext = new ApiDbContext();

        public BookmarksController() 
        {
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
            
        //    var bookmarks = from b in dbContext.Bookmarks.Where(b => b.User_Id == )
        //}
    }
}
