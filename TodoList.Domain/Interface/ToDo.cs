using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain;
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllTodoItems();
        Task<TodoItem> GetTodoItemById(int id);
        Task AddTodoItem(TodoItem todoItem);
        Task UpdateTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(int id);
    }
}


