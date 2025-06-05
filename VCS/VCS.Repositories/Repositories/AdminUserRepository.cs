using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Context;
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;

namespace VCS.Repositories.Repositories {
    public class AdminUserRepository(VCSDbContext _missionDb) : IAdminUserRepository {
        public List<UserDetails> UserDetailsList() {
            var res = _missionDb.User.Where(x => !x.IsDeleted && x.UserType == "user").Select(x => new UserDetails(x));
            return res.ToList();
        }
        public string DeleteUser(int id) {
            var user = _missionDb.User.Where(x => x.Id == id).FirstOrDefault();

            if (user == null) throw new Exception("Account does't exist!");

            user.IsDeleted = true;

            //user.EmailAddress = model.EmailAddress

            user.ModifiedDate = DateTime.Now;
            _missionDb.User.Update(user);
            _missionDb.SaveChanges();
            return "Account deleted!";
        }
    }
}
