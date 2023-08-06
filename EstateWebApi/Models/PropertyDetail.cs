using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateV1App.Models
{
    public class PropertyDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        //public Bookmark Bookmark { get; set; }
    }
}
