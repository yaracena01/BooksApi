using Book.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service
{
    public class BooksService : IBooksService
    {
        private HttpClient _httpClient;
        public BooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Books>> Get()
        {
            var response = await _httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Books>>(apiResponse);       
        }
    }
}
