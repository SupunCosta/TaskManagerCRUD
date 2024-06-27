using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;


public class Task
{
    [Key]
    [ValidateNever]
    public string Id { get; set; }

    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter dueDate")]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
}

public class TaskCreate
{

    public string Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }
}