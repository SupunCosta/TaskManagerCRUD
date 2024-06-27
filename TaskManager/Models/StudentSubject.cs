using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class StudentSubject
{
    [Key]
    public string Id { get; set; }

    public string? StudentId { get; set; }
    public Student? Student { get; set; }
    
    public string? SubjectId { get; set; }
    public Subject? Subject { get; set; }

}