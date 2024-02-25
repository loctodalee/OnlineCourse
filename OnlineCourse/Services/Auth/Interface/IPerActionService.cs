using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.Interface
{
    public interface IPerActionService
    {
        Task<List<PermissionActionModel>> GetAll();
        Task<PermissionActionModel> GetById(string id);
        Task<PermissionActionModel> CreatePerAction(RequestCreatePerActionModel model);
        Task UpdatePerAction(PermissionActionModel model);
        Task DeletePerAction(string id);
    }
}
