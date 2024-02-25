using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IUserPerService
    {
        Task<List<UserPermissionModel>> GetAll();
        Task<UserPermissionModel> GetById(string id);
        Task<UserPermissionModel> CreateUserPer(RequestCreateUserPerModel model);
        Task UpdateUserPer(UserPermissionModel model);
        Task DeleteUserPer(string id);
        
    }
}
