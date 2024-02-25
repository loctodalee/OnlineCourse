using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IPermissionService
    {
        Task<List<PermissionModel>> GetPermissionsAsync();
        Task<PermissionModel> GetPermissionByIdAsync(string id);
        Task<PermissionModel> CreatePermission(RequestCreatePermissionModel model);
        Task UpdatePermission(PermissionModel model);
        Task DeletePermissionAsync(string id);
    }
}
