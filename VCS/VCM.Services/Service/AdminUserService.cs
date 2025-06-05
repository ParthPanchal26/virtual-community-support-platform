using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;
using VCS.Services.IService;

namespace VCS.Services.Service {
    public class AdminUserService(IAdminUserRepository _adminUserRepository) : IAdminUserService {
        public List<UserDetails> UserDetailsList() {
            return _adminUserRepository.UserDetailsList();
        }
        public string UserDelete(int id) {
            return _adminUserRepository.DeleteUser(id);
        }
    }
}
