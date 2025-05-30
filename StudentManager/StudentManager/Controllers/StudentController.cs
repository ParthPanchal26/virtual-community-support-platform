using Microsoft.AspNetCore.Mvc;
using Student.Service.Services;
using Student.Service.Services;
using Student.DataAccess.Models;

namespace StudentManager.Controllers
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
        public ActionResult<List<Students>> GetStudents()
        {
            List<Students> students = _studentService.GetStudents();
            if (students == null || students.Count == 0)
            {
                return NotFound("404! No Record Found!");
            }
            else
            {
                return Ok(students);
            }
        }

        [HttpGet("GetStudent")]
        public ActionResult<List<Students>> GetStudent(int id)
        {
            Students std = _studentService.GetStudent(id);

            if (std == null)
            {
                return NotFound("404! Invalid Id!");
            }
            else
            {
                return Ok(std);
            }
        }

            [HttpPost]
        public ActionResult<List<Students>> AddStudent(Students student)
        {
            _studentService.AddStudent(student);
            return Ok("Student Created!");
        }

        [HttpPut]
        public ActionResult<List<Students>> updateStudent(Students student)
        {
            int std = _studentService.updateStudent(student);
            if (std == -1)
            {
                return NotFound("404! Student Not Found!");
            }
            else if (std == 1)
            {
                return Ok("Student Updated!");
            }
            else
            {
                return BadRequest("Bad request!");
            }
        }

        [HttpDelete]
        public ActionResult<List<Students>> deleteStudent(int id)
        {
            int deleteStatus = _studentService.deleteStudent(id);
            if (deleteStatus == -1)
            {
                return NotFound("404! Student Not Found");
            }
            else if (deleteStatus == 1)
            {
                return Ok("Student Deleted!");
            }
            else
            {
                return BadRequest("Bad request!");
            }
        }

        [HttpGet("GetFilteredStudent")]
        public ActionResult GetFilteredStudent(string sem_class)
        {
            List<Students> student = _studentService.GetFilteredStudent(sem_class);
            if(student == null || student.Count == 0)
            {
                return NotFound("Student not found!");
            }
            else
            {
                return Ok(student);
            }

        }

    }

}
