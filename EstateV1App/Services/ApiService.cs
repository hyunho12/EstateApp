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

        public static async Task<List<TrendingProperty>> GetRealProperties()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetRealProperty");
            return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        }

        public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetRealPropertyList?categoryId=" + categoryId);
            return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        }

        public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetRealPropertyDetail?propertyId=" + propertyId);
            return JsonConvert.DeserializeObject<PropertyDetail>(response); // 현재 api서버에서 list 형식으로 반환 json 매핑 오류
        }
    }
}
