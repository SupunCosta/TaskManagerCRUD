using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Repository;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController:ControllerBase
{
    private readonly TaskManagerContext _context;
    private readonly IConfiguration Configuration;   
   
           public StudentController(TaskManagerContext context, IConfiguration configuration)
           {
   
               _context = context;
               Configuration = configuration;   
   
           }
   
           [HttpGet]
           public async Task<ActionResult> All()
           {
               try
               {
                   // var result = _context.Student
                   //     .Select(b => b.Subjects).ToList();
                   
                   var result = _context.Student.Include(s =>s.StudentSubject)!.ThenInclude(x => x.Subject).ToList()
                       .Select(s => new GetStudentDto
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Age = s.Age,
                           Subjects = s.StudentSubject!.Select(ss => ss.Subject).Select(n => new Subject()
                           {
                             Id  = n.Id,
                             Name = n.Name
                           }).ToList()
                       })
                       .ToList();
                   return Ok(result);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
   
           [HttpGet("{id}")]
           public async Task<ActionResult> Get(string id)
           {
               try
               {
                   var result = _context.Student.Include(x => x.StudentSubject).FirstOrDefault(x => x.Id == id);
                   return Ok(result);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
           }
   
           [HttpPost]
           public async Task<ActionResult> Create([FromBody] Student dto)
           {
               try
               {
                   dto.Id = Guid.NewGuid().ToString();

                   await _context.Student.AddAsync(dto);
                   await _context.SaveChangesAsync();

                   return Ok(dto);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
   
           [HttpPut("{id}")]
           public async Task<ActionResult> Update(string id, [FromBody] Student dto)
           {
               try
               {
                   var data = _context.Student.FirstOrDefault(x => x.Id == id);

                   var result = _context.Student.Update(dto);
                   await _context.SaveChangesAsync();     
                   
                   return Ok(result);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
           }
   
           [HttpDelete("{id}")]
           public async Task<ActionResult> Delete(string id)
           {
               try
               {
                   var data = _context.Student.FirstOrDefault(x => x.Id == id);

                   _context.Student.Remove(data);
                   return Ok(id);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
           } 
           
           [HttpPost("CreateSubject")]
           public async Task<ActionResult> CreateSubject([FromBody] Subject dto)
           {
               try
               {
                   dto.Id = Guid.NewGuid().ToString();

                   await _context.Subject.AddAsync(dto);
                   await _context.SaveChangesAsync();

                   return Ok(dto);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
           
           [HttpGet("GetSubjectList")]
           public async Task<ActionResult> GetSubjectList()
           {
               try
               {

                   var result = _context.Subject.ToList();
                   return Ok(result);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
           
           [HttpPost("AddStudentSubject")]
           public async Task<ActionResult> AddStudentSubject([FromBody] StudentSubject dto)
           {
               try
               {
                   dto.Id = Guid.NewGuid().ToString();

                   await _context.StudentSubject.AddAsync(dto);
                   await _context.SaveChangesAsync();

                   return Ok(dto);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
           
           [HttpGet("GetStudentSubjectById/{id}")]
           public async Task<ActionResult> GetStudentSubjectById(string id)
           {
               try
               {

                  var result =  _context.StudentSubject.Where(x => x.StudentId == id).Include(c => c.Subject);

                   return Ok(result);
   
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
   
               }
   
           }
    
}