using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Models;

namespace VCS.Services.IService {
    public interface IAdminUserService {
        List<UserDetails> UserDetailsList();
        string UserDelete(int id);
    }
}
