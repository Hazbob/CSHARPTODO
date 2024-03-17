using Todos.Models;

namespace Todos.Interfaces;

public interface ITodoListRepository
{
    ICollection<TodoItem> GetTodos();
    TodoItem GetTodo();

    TodoItem CreateTodo(string description, bool isCompleted);
}