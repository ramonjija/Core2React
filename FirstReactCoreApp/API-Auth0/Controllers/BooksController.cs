using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API_Auth0.Domain.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace API_Auth0.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BooksController : Controller
    {
        public BooksController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        [Authorize]
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

        [HttpGet]
        public ActionResult TestConfig(string key) {
            string value = Configuration[key];
            if(string.IsNullOrWhiteSpace(value))
                value = "String Vazia";
            return Ok(value);
        }
    }
}