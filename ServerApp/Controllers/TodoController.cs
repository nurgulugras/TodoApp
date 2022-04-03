using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using ServerApp.Services.Abstract;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController:ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> GetTodos()
        {
            var todos= await _todoService.GetTodosAsync();
            return Ok(todos);
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var todo = await _todoService.GetTodoIdAsync(id);
            if(todo == null){
               return NotFound(todo);
            }
            return Ok(todo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo model)
        {
            var todo=await _todoService.SaveTodoAsync(model);
            return Ok(todo);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            if(id==0)
            return BadRequest("Not valid request");

            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            await _todoService.DeleteTodoAsync(id);
           
            return Ok();
        }
    }
}