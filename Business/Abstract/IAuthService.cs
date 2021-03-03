using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegister, string password);

		IDataResult<User> Login(UserLoginDto userForLogin);
        IResult Exists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
