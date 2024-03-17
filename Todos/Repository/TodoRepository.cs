using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Todos.Interfaces;
using Todos.Models;

namespace Todos.Repository;

public class TodoRepository: ITodoListRepository
{
    private readonly TodoContext _todoContext;

    public TodoRepository(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }
    public ICollection<TodoItem> GetTodos()
    {
        return _todoContext.TodoItems.ToList();
    }

    public TodoItem GetTodo()
    {
        throw new NotImplementedException();
    }

    public TodoItem CreateTodo(string description, bool isCompleted)
    {
        var newTodo = new TodoItem
        {
            Description = description,
            IsCompleted = isCompleted
        };
        _todoContext.TodoItems.Add(newTodo);
        _todoContext.SaveChanges();

        return newTodo;
    }

}