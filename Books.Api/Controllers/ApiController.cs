using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Y.DataModels;
using Y.Repository;


namespace Y.Api.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IfakerestapiService fakerestapiService;
        public ApiController(IfakerestapiService _fakerestapiService)
        {
            fakerestapiService = _fakerestapiService;
            
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Books()
        {
            return await fakerestapiService.GetBooksAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Books(int id)
        {
            return await fakerestapiService.GetBooksByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Books(Book book)
        {
            var model = await fakerestapiService.CreateBooksAsync(book);
            return CreatedAtAction(nameof(Books), new { id= model.id}, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Books(int id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }
            await fakerestapiService.UpdateBooksAsync(id, book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooks(int id)
        {
            var model = await fakerestapiService.GetBooksByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await fakerestapiService.DeleteBooksAsync(id);
            return NoContent();
        }

    }
}
