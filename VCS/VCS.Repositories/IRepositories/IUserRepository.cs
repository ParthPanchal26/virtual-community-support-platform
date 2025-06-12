using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Models;

namespace VCS.Repositories.IRepositories {
    public interface IUserRepository {
        Task<string> DeleteUser(int id);
        Task<UserResponseModel> GetUserById(int id);

        Task<List<UserResponseModel>> GetAllUsers();
    }
}
