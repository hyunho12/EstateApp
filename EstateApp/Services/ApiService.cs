using EstateApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateApp.Services
{
    public class ApiService
    {
        public static async Task<bool> RegisterUser(string name, string email, string password, string phone)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                Phone = phone
            };
            var httpClient = new HttpClient(); // HTTP Post요청을 보내기위해서 HttpClient의 새로운 인스턴스생성
            var json = JsonConvert.SerializeObject(register); // 'register' 객체를 JSON형식으로 직렬화한다.
            var content = new StringContent(json, Encoding.UTF8, "application/json"); // json데이터를 'application/json' 컨텐츠 타입으로 가지는 StringContent객체생성
            var response = await httpClient.PostAsync("localhost/users/register", content);
            if(!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }             

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("localhost/users/login", content);

            if(!response.IsSuccessStatusCode) 
            {
                return false;
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accesstoken", result.AccessToken);
            Preferences.Set("userid", result.UserId);
            Preferences.Set("username", result.UserName);

            return true;
        }
        
        public static async Task<List<Category>> GetCategories()
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization 
            var response = await httpClient.GetStringAsync("categories");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public static async Task<List<TrendingProperty>> GetTrendingProperties()
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer")
            var response = await httpClient.GetStringAsync("localhost/Properties/TrendingProperties");
            return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        }

        public static async Task<List<SearchProperty>> FindProperties(string address)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("localhost/Properties/SearchProperties?address=" + address);
            return JsonConvert.DeserializeObject<List<SearchProperty>>(response);
        }

        public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("localhost/Properties/PropertyList?categoryId=" + categoryId);
            return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        }

        public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("localhost/Properties/PropertyDetail?id=" + propertyId);
            return JsonConvert.DeserializeObject<PropertyDetail>(response);
        }

        public static async Task<List<BookmarkList>> GetBookmarkList()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("localhost/bookmarks");
            return JsonConvert.DeserializeObject<List<BookmarkList>>(response);
        }

        public static async Task<bool> AddBookmark(AddBookmark addBookmark)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(addBookmark);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("localhost/bookmarks", content);
            if (!response.IsSuccessStatusCode) { return false; }
            return true;
        }

        public static async Task<bool> DeleteBookmark(int bookmarkId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync("localhost/bookmarks/" + bookmarkId);
            if (!response.IsSuccessStatusCode) { return false; }
            return true;
        }
    }
}
