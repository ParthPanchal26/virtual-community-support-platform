using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Models;

namespace VCS.Repositories.IRepositories {
    public interface IAdminUserRepository {
        List<UserDetails> UserDetailsList();
        string DeleteUser(int id);
    }
}
