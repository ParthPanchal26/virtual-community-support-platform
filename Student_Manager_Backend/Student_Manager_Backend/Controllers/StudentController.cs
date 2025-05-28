using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Manager_Backend.Models;
using Student_Manager_Backend.Services;

namespace Student_Manager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public ActionResult<List<Student>> GetStudents()
        {
            List<Student> students = _studentService.GetStudents();
            if(students == null || students.Count == 0)
            {
                return NotFound("404! No Record Found!");
            } else
            {
                return Ok(students);
            }
        }

        [HttpGet("GetStudent")]
        public ActionResult<List<Student>> GetStudent(int id)
        {
            Student std = _studentService.GetStudent(id);

            if (std == null)
            {
                return NotFound("404! Invalid Id!");
            } else
            {
                return Ok(std);
            }
        }

        [HttpPost]
        public ActionResult<List<Student>> AddStudent(Student student) 
        { 
            _studentService.AddStudent(student);
            return Ok("Student Created!");
        }

        [HttpPut]
        public ActionResult<List<Student>> updateStudent(Student student)
        { 
            int std = _studentService.updateStudent(student);
            if(std == -1)
            {
                return NotFound("404! Student Not Found!");
            }
            else if(std == 1)
            {
                return Ok("Student Updated!");
            } else
            {
                return BadRequest("Bad request!");
            }
        }

        [HttpDelete]
        public ActionResult<List<Student>> deleteStudent(int id) 
        {
            int deleteStatus = _studentService.deleteStudent(id);
            if (deleteStatus == -1)
            {
                return NotFound("404! Student Not Found");
            } else if(deleteStatus == 1)
            {
                return Ok("Student Deleted!");
            } else
            {
                return BadRequest("Bad request!");
            }
        }

    }
}
