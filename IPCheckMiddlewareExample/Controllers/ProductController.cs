using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPCheckMiddlewareExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Product[]
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1" },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2" },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3" },
                new Product { Id = 4, Name = "Product 4", Description = "Description 4" },
                new Product { Id = 5, Name = "Product 5", Description = "Description 5" },
            });
        }
    }
}
