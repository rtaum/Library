using Library.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private BooksRepository _booksRepository = new BooksRepository();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(_booksRepository.GetAllBooks()));
        }
    }
}
