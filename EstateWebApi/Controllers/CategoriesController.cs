﻿using EstateWebApi.Data;
using EstateWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace EstateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {      
        ApiDbContext dbContext = new ApiDbContext();

        //[HttpGet("GetCategory")]
        //public IActionResult GetCategory()
        //{
        //    List<Category> categories = new List<Category>
        //    {
        //        new Category { Id = 1, Name = "Hotel", ImageUrl = "hotel.png"},
        //        new Category { Id = 2, Name = "House", ImageUrl = "house.png"},
        //        new Category { Id = 3, Name = "Apartment", ImageUrl = "apartment.png"},
        //        new Category { Id = 4, Name = "Penthouse", ImageUrl = "penthouse.png"},                
        //    };

        //    return Ok(categories);
        //}


        //[HttpGet("[action]")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetCategory")]
        [Authorize]        
        public IActionResult GetCategory()
        {
            return Ok(dbContext.Categories);
        }
    }
}
