using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IUserPerService
    {
        Task<List<UserPermissionModel>> GetAll();
        Task<List<UserPermissionModel>> GetByUserId(string id);
        Task<UserPermissionModel> CreateUserPer(RequestCreateUserPerModel model);
        Task DeleteUserPer(UserPermissionModel model);
        
    }
}
