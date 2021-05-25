using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Y.DataModels;

namespace Y.UI.Services
{
    public class BookService: IBookService
    {
        private readonly HttpClient httpClient;
        public BookService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var httpResponse = await httpClient.GetJsonAsync<IEnumerable<Book>>("api/Books");
            return httpResponse;
        }
        public async Task<Book> GetBooksById(int id)
        {
            var httpResponse = await httpClient.GetJsonAsync<Book>($"api/Books/{id}");
            return httpResponse;
        }
        public async Task<ResponseStatusData> CreateBooks(Book book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await httpClient.PostAsync("api/Books", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new ResponseStatusData { 
                    statusCode= (int)httpResponse.StatusCode,
                    error = httpResponse.ReasonPhrase                  
                };
            }
            return new ResponseStatusData
            {
                data  = JsonConvert.DeserializeObject<Book>(await httpResponse.Content.ReadAsStringAsync()),
                statusCode = (int)httpResponse.StatusCode
            };
        }

        public async Task<ResponseStatusData> UpdateBooks(int id, Book book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await httpClient.PutAsync($"api/Books/{id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new ResponseStatusData
                {
                    statusCode = (int)httpResponse.StatusCode,
                    error = httpResponse.ReasonPhrase
                };
            }
            return new ResponseStatusData
            {
                data = JsonConvert.DeserializeObject<Book>(await httpResponse.Content.ReadAsStringAsync()),
                statusCode = (int)httpResponse.StatusCode
            };
        }

        public async Task DeleteBooks(int id)
        {
            await httpClient.DeleteAsync($"api/Books/{id}");
        }
    }
}
