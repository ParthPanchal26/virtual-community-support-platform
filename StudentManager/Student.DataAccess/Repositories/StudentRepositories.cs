using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DataAccess.Models;

namespace Student.DataAccess.Repositories
{
    public class StudentRepositories
    {
        private readonly StudentDBContext _dbContext;

        public StudentRepositories(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Students> GetStudents()
        {
            return _dbContext.Student.ToList();
        }

        public Students GetStudent(int id)
        {
            Students student = _dbContext.Student.FirstOrDefault(student => student.Id == id);

            if (student == null)
            {
                return null;
            }
            return student;
        }

        public void AddStudent(Students student)
        {
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();
        }

        public int updateStudent(Students std)
        {
            Students student = GetStudent(std.Id);

            if (student == null)
            {
                return -1;
            }
            else
            {
                student.name = std.name;
                student.sem_class = std.sem_class;
                student.er_no = std.er_no;
                _dbContext.SaveChanges();
                return 1;
            }

        }

        public int deleteStudent(int id)
        {
            Students std = GetStudent(id);

            if (std == null)
            {
                return -1;
            }
            else
            {
                _dbContext.Remove(std);
                _dbContext.SaveChanges();
                return 1;
            }

        }

        public List<Students> GetFilteredStudent(string sem_class)
        {
            List<Students> student = _dbContext.Student.Where(student => student.sem_class.Equals(sem_class)).ToList();
            return student;
        }

    }
}
