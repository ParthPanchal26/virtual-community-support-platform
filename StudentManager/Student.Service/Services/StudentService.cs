using Microsoft.EntityFrameworkCore;
using Student.DataAccess.Models;
using Student.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service.Services
{
    public class StudentService
    {
        private readonly StudentRepositories _studentRepositories;

        public StudentService(StudentRepositories studentRepositories)
        {
            _studentRepositories = studentRepositories;
        }

        public List<Students> GetStudents()
        {
            return _studentRepositories.GetStudents();
        }

        public Students GetStudent(int id)
        {
            return _studentRepositories.GetStudent(id);
        }

        public void AddStudent(Students student)
        {
            _studentRepositories.AddStudent(student);
        }

        public int updateStudent(Students std)
        {
           return _studentRepositories.updateStudent(std);
        }

        public int deleteStudent(int id)
        {
            return _studentRepositories.deleteStudent(id);
        }

        public List<Students> GetFilteredStudent(string sem_class)
        {
            return _studentRepositories.GetFilteredStudent(sem_class);
        }

    }
}
