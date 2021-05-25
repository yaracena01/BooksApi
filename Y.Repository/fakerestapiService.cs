using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Y.DataModels;

namespace Y.Repository
{
    public class fakerestapiService : IfakerestapiService
    {
        private const string baseUrl = "Api/v1/books/";
        private readonly HttpClient httpClient;
        public fakerestapiService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Book>> GetBooksAllAsync()
        {
            var httpResponse = await httpClient.GetAsync(baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new List<Book>();
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var allBooks = JsonConvert.DeserializeObject<List<Book>>(content);

            return allBooks;
        }

        public async Task<Book> GetBooksByIdAsync(int id)
        {
            var httpResponse = await httpClient.GetAsync($"{baseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.ReasonPhrase);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var getBook = JsonConvert.DeserializeObject<Book>(content);

            return getBook;
        }

        public async Task<Book> CreateBooksAsync(Book book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await httpClient.PostAsync(baseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.ReasonPhrase);
            }

            var createdBook = JsonConvert.DeserializeObject<Book>(await httpResponse.Content.ReadAsStringAsync());
            return createdBook;
        }

        public async Task<Book> UpdateBooksAsync(int id, Book book)
        {
            var content = JsonConvert.SerializeObject(book);
            var httpResponse = await httpClient.PutAsync($"{baseUrl}{id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.ReasonPhrase);
            }

            var updateBook = JsonConvert.DeserializeObject<Book>(await httpResponse.Content.ReadAsStringAsync());
            return updateBook;
        }

        public async Task DeleteBooksAsync(int id)
        {
            var httpResponse = await httpClient.DeleteAsync($"{baseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.ReasonPhrase);
            }
        }
    }
}
