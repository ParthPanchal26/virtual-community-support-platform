using VCS.Entities.Models;
using VCS.Repositories.IRepositories;
using VCS.Services.IServices;

namespace VCS.Services.Services {
    public class UserService(IUserRepository userRepository) : IUserService {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> DeleteUser(int id) {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<UserResponseModel> GetUserById(int id) {
            return await _userRepository.GetUserById(id);
        }

        public async Task<List<UserResponseModel>> GetAllUsers() {
            return await _userRepository.GetAllUsers();
        }
    }
}
