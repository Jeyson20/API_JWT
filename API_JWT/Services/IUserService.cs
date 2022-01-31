using API_JWT.Models.Request;
using API_JWT.Models.Response;

namespace API_JWT.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
