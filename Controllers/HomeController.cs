using Microsoft.AspNetCore.Mvc;

namespace MinhaAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
       [HttpGet("/")]
       public string Get()
        {
            return "Hello World";
        }
    }
}
