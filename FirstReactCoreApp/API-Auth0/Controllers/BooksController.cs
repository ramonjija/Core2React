using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API_Auth0.Domain.Model;

namespace API_Auth0.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet]
        public IEnumerable<Book> Get() 
        {
            var currentUser = HttpContext.User;
            var resultBookList  = new Book[]
            {
                new Book("Ray Bradbury", "Fahrenheit 451", false),
                new Book("Gabriel García Márquez", "One Hundred years of Solitude", false),
                new Book("Anais Nin", "Delta of Venus", true)
            };

            return resultBookList;
        }
    }
}