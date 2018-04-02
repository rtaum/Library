using Library.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Library.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var books = new List<Book> {
                    new Book() { Id = 101, Author = "Agatha Christie", Title = "Murder on the Orient Express", PublicationDate = new DateTime(1934, 1, 1) },
                    new Book() { Id = 102, Author = "Lewis Carroll", Title = "Alice's Adventures in Wonderland", PublicationDate = new DateTime(1865, 11, 26) },
                    new Book() { Id = 103, Author = "Jack London", Title = "The Sea-Wolf", PublicationDate = new DateTime(1904, 11, 26) }
                };

            return Ok(JsonConvert.SerializeObject(books));
        }
    }
}
