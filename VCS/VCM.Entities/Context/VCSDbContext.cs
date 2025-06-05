using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Entities;

namespace VCS.Entities.Context {
    public class VCSDbContext(DbContextOptions<VCSDbContext> options) : DbContext(options) {
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<User>().HasData(new User() {
                Id = 1,
                FirstName = "test",
                LastName = "tester",
                EmailAddress = "test@gmail.com",
                UserType = "admin",
                Password = "test@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UserImage = "default.png"
            });

            base.OnModelCreating(builder);
        }
    }
}
