using System.Collections.Generic;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Services.Abstract
{
    public interface ITodoService
    {
        Task<Todo> GetTodoIdAsync(int id);
        Task<List<Todo>> GetTodosAsync();
        Task<Todo> SaveTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}