using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userForRegisterDto);

        IDataResult<User> Login(UserLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}