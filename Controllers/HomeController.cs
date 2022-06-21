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


        [HttpGet("/{id:int}")]
        public Todo GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);

            return todo;
        }


        [HttpPost("/")]
        public Todo Post(
            [FromBody] Todo todo, 
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return todo;
        }


        [HttpPut("/{id:int}")]
        public Todo Put(
            [FromRoute] int id,
            [FromBody] Todo todo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return null;

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return model;
        }


        [HttpDelete("/{id:int}")]
        public string Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            context.Todos.Remove(model);
            context.SaveChanges();

            return "Removido com sucesso";
        }
    }
}
