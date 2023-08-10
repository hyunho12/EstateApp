using EstateWebApi.Data;
using EstateWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Get()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);

            if(user == null) { return NotFound(); }

            var bookmarks = from b in dbContext.Bookmarks.Where(b => b.User_Id == user.Id)
                            join p in dbContext.RealProperties on b.RealPropertyId equals p.Id
                            where b.Status == true
                            select new
                            {
                                b.Id,
                                p.Name,
                                p.Price,
                                p.ImageUrl,
                                p.Address,
                                b.Status,
                                b.User_Id,
                                b.RealPropertyId
                            };

            return Ok(bookmarks);
        }

        [Authorize]
        [HttpPost("[action]")]
        public IActionResult BookmarkSave([FromBody] AddBookmark bookmarkItem)
        {
            Bookmark bookmark = new Bookmark
            {
                Status = true,
                User_Id = bookmarkItem.User_Id,
                RealPropertyId = bookmarkItem.PropertyId
            };
            
            dbContext.Bookmarks.Add(bookmark);
            dbContext.SaveChanges();
            return Ok("Bookmark added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookmarkResult = dbContext.Bookmarks.FirstOrDefault(b => b.Id == id);
            if(bookmarkResult == null)
            {
                return NotFound();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                if(user == null) return NotFound();
                if(bookmarkResult.User_Id == user.Id)
                {
                    dbContext.Bookmarks.Remove(bookmarkResult);
                    dbContext.SaveChanges();
                    return Ok("Bookmark delete!!");
                }
                return BadRequest();
            }
        }
    }
}
