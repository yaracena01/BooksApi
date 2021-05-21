using Book.Data;
using Book.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public ApiController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Books>> Books()
        {
            return await _booksService.Get();
        }
    }
}
