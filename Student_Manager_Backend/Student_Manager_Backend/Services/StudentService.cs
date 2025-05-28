using Microsoft.AspNetCore.Http.HttpResults;
using Student_Manager_Backend.Models;

namespace Student_Manager_Backend.Services
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
            
            students.Add(new Student()
            {
                Id = 1,
                name = "Parth_1",
                sem_class = "7CE2",
                er_no = 123123213
            });

            students.Add(new Student()
            {
                Id = 2,
                name = "Parth_2",
                sem_class = "9CE2",
                er_no = 564663213
            });

            students.Add(new Student()
            {
                Id = 3,
                name = "Parth_3",
                sem_class = "8CE2",
                er_no = 324243213
            });

        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            Student std = students.FirstOrDefault(std => std.Id == id);

            if(std == null)
            {
                return null;
            }
            return std;
        }

        public void AddStudent(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
        }

        public int updateStudent(Student std)
        {
            Student student = GetStudent(std.Id);

            if(student == null)
            {
                return -1;
            } else
            {
                student.name = std.name;
                student.sem_class = std.sem_class;
                student.er_no = std.er_no;
                return 1;
            }
            
        }

        public int deleteStudent(int id)
        {
            Student std = GetStudent(id);

            if(std == null)
            {
                return -1;
            }
            else
            {
                students.Remove(std);
                return 1;
            }
        }

    }
}
