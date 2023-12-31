﻿using EstateV1App.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateV1App.Services
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

            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(AppSettings.ApiUrl + "api/users/register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(AppSettings.ApiUrl + "api/users/login", content);
            if(!response.IsSuccessStatusCode) return false;
            
            //login이 성공시 값을 받아 인증토큰 생성
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);

            Preferences.Set("accessToken", result.AccessToken);
            Preferences.Set("userid", result.UserId);
            Preferences.Set("username", result.UserName);
            
            return true;
        }

        public static async Task<List<Category>> GetCategories()
        {
            HttpClient client = new HttpClient();
            // api http request요청을 보낼때 받은 인증토큰을 헤더(Authorization: Bearer 토큰문자열)로 보내 인증통과하도록 하고, 응답을 수신
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));

            var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/Categories/GetCategory");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetRealPropertyList?categoryId=" + categoryId);
            return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        }

        public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetPropertyDetail?propertyId=" + propertyId);
            return JsonConvert.DeserializeObject<PropertyDetail>(response); 
        }

        public static async Task<List<TrendingProperty>> GetRealProperties()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetTrendingProperties");
            return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        }

        public static async Task<List<SearchProperty>> FindProperties(string address)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await client.GetStringAsync(AppSettings.ApiUrl + "api/Properties/GetSearchProperties?address="+address);
            return JsonConvert.DeserializeObject<List<SearchProperty>>(response);
        }

        public static async Task<List<BookmarkList>> GetBookmarkList()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Bookmarks");
            return JsonConvert.DeserializeObject<List<BookmarkList>>(response);
        }

        public static async Task<bool> AddBookmark(AddBookmark addBookmark)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));

            var json = JsonConvert.SerializeObject(addBookmark);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Bookmarks/BookmarkSave", content);
            if(!response.IsSuccessStatusCode) { return false; }
            return true;
        }

        public static async Task<bool> DeleteBookmark(int bookmarkId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.DeleteAsync(AppSettings.ApiUrl + "api/Bookmarks/" + bookmarkId);
            if (!response.IsSuccessStatusCode) { return false; }
            return true;
        }
    }
}
