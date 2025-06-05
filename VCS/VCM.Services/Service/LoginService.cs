using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Entities;
using VCS.Entities.Models;
using VCS.Repositories.Helper;
using VCS.Repositories.IRepositories;
using VCS.Services.IService;

namespace VCS.Services.Service {
    public class LoginService(ILoginRepository loginRepository, JwtService jwtService) : ILoginService {
        private readonly ILoginRepository _loginRepository = loginRepository;
        private readonly JwtService _jwtService = jwtService;
        ResponseResult result = new ResponseResult();

        public ResponseResult LoginUser(LoginUserRequestModel model) {
            var userObj = UserLogin(model);

            if (userObj.Message.ToString() == "Login Successfully") {
                result.Message = userObj.Message;
                result.Result = ResponseStatus.Success;
                result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress, userObj.UserType, userObj.UserImage);
            } else {
                result.Message = userObj.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        public LoginUserResponseModel UserLogin(LoginUserRequestModel model) {
            return _loginRepository.LoginUser(model);
        }

        public Task<string> Register(RegisterUserModel model) {
            return _loginRepository.Register(model);
        }


    }
}
