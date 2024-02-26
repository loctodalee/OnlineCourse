using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Auth.Response;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IAuthenticationService
    {
        Task<ResponseLoginModel> Authenticator(RequestLoginModel request);
        Task<ResponseLoginModel> RefreshToken (string token);
    }
}
