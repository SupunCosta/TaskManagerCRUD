using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class Subject
{
    [Key]
    public string Id { get; set; }

    public string? Name { get; set; }
    public List<StudentSubject>? StudentSubject { get; set; }

}