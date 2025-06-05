using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Entities;
using VCS.Entities.Models;

namespace VCS.Services.IService {
    public interface ILoginService {
        ResponseResult LoginUser(LoginUserRequestModel model);

        LoginUserResponseModel UserLogin(LoginUserRequestModel model);
        Task<string> Register(RegisterUserModel model);
    }
}
