using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class TaskManagerContext:DbContext
    {
      
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }

        // public DbSet<Task> Task { get; set; } = null!;
        public DbSet<Student> Student { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }

    }
}
