using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Y.DataModels;

namespace Y.Repository
{
    public interface IfakerestapiService
    {
        Task<List<Book>> GetBooksAllAsync();
        Task<Book> GetBooksByIdAsync(int id);
        Task<Book> CreateBooksAsync(Book book);
        Task<Book> UpdateBooksAsync(int id, Book book);
        Task DeleteBooksAsync(int id);
    }
}
