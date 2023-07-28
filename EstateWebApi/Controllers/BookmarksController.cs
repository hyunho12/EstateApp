using EstateWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        public BookmarksController() 
        {
        }

        [HttpGet("GetBookmarks")]
        public ActionResult GetBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>
            {
                new Bookmark {Id = 1, Status = true, User_Id = 4, PropertyId = 2},
                new Bookmark {Id = 2, Status = true, User_Id = 3, PropertyId = 4},
                new Bookmark {Id = 3, Status = true, User_Id = 1, PropertyId = 1},
                new Bookmark {Id = 4, Status = true, User_Id = 2, PropertyId = 3},
                new Bookmark {Id = 5, Status = true, User_Id = 3, PropertyId = 4},
            };

            return Ok(bookmarks);
        }
    }
}
