using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Email;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IUserService
    {
        //Task<UserModel> CreateUser(UserModel model);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(string id);
        Task<UserModel> CreateUser(RequestCreateUserModel user);
        Task<UserModel> RegisterUser(RequestCreateUserModel user);
        Task VerifyEmail(RequestVerifyModel model); 
        Task UpdateUser(UserModel model);
        Task DeleteUser(string id);
    }
}
