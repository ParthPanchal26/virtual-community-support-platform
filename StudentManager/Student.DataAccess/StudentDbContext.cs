using Student.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Student.DataAccess
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }

        public DbSet<Students> Student { get; set; }
    }


}
