using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class Student
{
    [Key]
    public string Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }
    public List<StudentSubject>? StudentSubject { get; set; }

    
}

public class GetStudentDto
{
    [Key]
    public string Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }
    public List<Subject?> Subjects { get; set; }

    
}