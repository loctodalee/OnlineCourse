using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IPerActionService
    {
        Task<List<PermissionActionModel>> GetAll();
        Task<List<PermissionActionModel>> GetByPermissionId(string id);
        Task<PermissionActionModel> CreatePerAction(RequestCreatePerActionModel model);
        Task DeletePerAction(PermissionActionModel model);
    }
}
