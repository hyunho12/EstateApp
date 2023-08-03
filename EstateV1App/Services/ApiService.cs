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
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.0.2:5299" : "http://localhost:5299";
        public static string BaseUrl = $"{BaseAddress}/api/controller";

        public static async Task<List<Category>> GetCategories()
        {
            HttpClient client = new HttpClient();
            //var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.0.2:5299/" : "http://localhost:5299/";
            var response = await client.GetStringAsync(BaseUrl + "/GetCategory");
            //var response = await client.GetStringAsync($"{baseUrl}api/controller/GetCategory");
            //var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/controller/GetCategory");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }


    }
}
