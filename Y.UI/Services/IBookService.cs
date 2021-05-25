using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Y.DataModels;

namespace Y.UI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBooksById(int id);
        Task<ResponseStatusData> CreateBooks(Book book);
        Task<ResponseStatusData> UpdateBooks(int id, Book book);
        Task DeleteBooks(int id);
    }
}
