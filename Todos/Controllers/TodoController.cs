using Microsoft.AspNetCore.Mvc;
using Todos.Interfaces;
using Todos.Models;
using Todos.Repository;

namespace Todos.Controllers;
[ApiController]
public class TodoController : Controller
{
    private ITodoListRepository _todoListRepository;

    public TodoController(ITodoListRepository todoListRepository)
    {
        this._todoListRepository = todoListRepository;
    }
    // GET
    [HttpGet]
    [Route("[controller]")]
    public IActionResult GetTodos()
    {
        
        ICollection<TodoItem> todos = this._todoListRepository.GetTodos();
        Console.WriteLine(todos.Count());
        if (todos.Count() == 0)
        {
            return NotFound();
        }
        else
        {
            return Ok(todos);
        }
   
    }
    [HttpPost]
    [Route("[controller]")]
    public IActionResult CreateTodo(string description, bool isCompleted)
    {
        TodoItem newTodo = this._todoListRepository.CreateTodo(description, isCompleted);
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Input");
        }

        return Ok(newTodo);

    }

}