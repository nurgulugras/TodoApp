using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerApp.Data;
using ServerApp.Models;
using ServerApp.Services.Abstract;

namespace ServerApp.Services.Concrete
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;

        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task DeleteTodoAsync(int id)
        {
            var dbTodo=await _todoRepository.GetEntityByIdAsync(id);
            await _todoRepository.DeleteAsync(dbTodo);
        }

        public async Task<Todo> GetTodoIdAsync(int id)
        {
            var todo = await _todoRepository.GetEntityByIdAsync(id);
            return todo;
        }

        public Task<List<Todo>> GetTodosAsync()
        {
            return _todoRepository.GetsAsync();
        }

        public Task<Todo> SaveTodoAsync(Todo todo)
        {
            todo.Date=DateTime.Now;
            return _todoRepository.SaveAsync(todo);
        }
    }
}