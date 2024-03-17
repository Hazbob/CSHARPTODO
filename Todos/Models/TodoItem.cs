using System.ComponentModel.DataAnnotations;

namespace Todos.Models;

public class TodoItem
{
    public int Id { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
    [Required]
    public string Description { get; set; }
}