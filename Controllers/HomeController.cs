using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
       [HttpGet("/")]
       public List<Todo> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }
    }
}
