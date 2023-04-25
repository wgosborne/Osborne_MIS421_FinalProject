using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _521Final.Models
{
    public class MicrosoftBooksAPI
    {
        private readonly HttpClient _httpClient;

        public MicrosoftBooksAPI(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.cognitive.microsoft.com/bing/v7.0/");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
        }

        public async Task<string> SearchBooks(string query)
        {
            string endpoint = "books/search";
            string url = endpoint + "?q=" + System.Net.WebUtility.UrlEncode(query);

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Failed to search books: {response.StatusCode}");
            }
        }
    }
}

