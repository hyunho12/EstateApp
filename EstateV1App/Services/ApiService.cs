using EstateV1App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateV1App.Services
{
    public class ApiService
    {
        public static async Task<List<Category>> GetCategories()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/Categories/GetCategory");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }


    }
}
