using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Context;
using VCS.Entities.Entities;
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;

namespace VCS.Repositories.Repositories {
    public class LoginRepository(VCSDbContext cIDbContext) : ILoginRepository {
        private readonly VCSDbContext _cIDbContext = cIDbContext;

        public LoginUserResponseModel LoginUser(LoginUserRequestModel model) {
            var existingUser = _cIDbContext.User
                .FirstOrDefault(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower() && !u.IsDeleted);

            if (existingUser == null) {
                return new LoginUserResponseModel() { Message = "Email Address Not Found." };
            }
            if (existingUser.Password != model.Password) {
                return new LoginUserResponseModel() { Message = "Incorrect Password." };
            }

            return new LoginUserResponseModel {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName ?? string.Empty,
                LastName = existingUser.LastName ?? string.Empty,
                PhoneNumber = existingUser.PhoneNumber,
                EmailAddress = existingUser.EmailAddress,
                UserType = existingUser.UserType,
                UserImage = existingUser.UserImage != null ? existingUser.UserImage : string.Empty,
                Message = "Login Successfully"
            };
        }

        public async Task<string> Register(RegisterUserModel model) {
            var isExist = _cIDbContext.User.Where(x => x.EmailAddress == model.EmailAddress && !x.IsDeleted).FirstOrDefault();

            if (isExist != null) throw new Exception("Email already exist");

            User user = new User() {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                UserType = "user",
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                UserImage = string.IsNullOrWhiteSpace(model.UserImage) ? "" : model.UserImage
            };

            await _cIDbContext.User.AddAsync(user);
            _cIDbContext.SaveChanges();
            return "User Added!";
        }
    }

}
