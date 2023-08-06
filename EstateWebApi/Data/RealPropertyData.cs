using EstateWebApi.Models;

namespace EstateWebApi.Data
{
    public class RealPropertyData
    {
        List<RealProperty> properties = new List<RealProperty>()
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
        //List<RealProperty> RealProperties = {}
    }
}
