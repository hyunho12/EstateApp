using System.Text.Json.Serialization;

namespace EstateWebApi.Models
{
    public class Bookmark
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int User_Id { get; set; }
        public int RealPropertyId { get; set; }
        [JsonIgnore]
        public RealProperty Property { get; set; }
    }
}
