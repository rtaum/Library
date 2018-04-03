using Library.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Order.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private BooksRepository _booksRepository = new BooksRepository();

        [HttpPost("{id}")]
        public IActionResult Post([FromRoute] int id)
        {
            var book = _booksRepository.GetBookById(id);
            if (book == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok();
        }
    }
}
