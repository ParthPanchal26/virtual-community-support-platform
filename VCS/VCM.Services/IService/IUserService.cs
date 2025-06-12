
using VCS.Entities.Models;
using VCS.Entities.Models;

namespace VCS.Services.IServices {
    public interface IUserService {
        Task<UserResponseModel> GetUserById(int id);
        Task<string> DeleteUser(int id);
        Task<List<UserResponseModel>> GetAllUsers();
    }

}
