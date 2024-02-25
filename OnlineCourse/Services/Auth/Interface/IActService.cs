using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;

namespace OnlineCourse.Services.Auth.NewFolder
{
    public interface IActService
    {
        Task<List<ActModel>> GetActions();
        Task<ActModel> GetActionById(string id);
        Task<ActModel> CreateAction(RequestCreateActionModel model);
        Task<ActModel> UpdateAction(ActModel model);
        Task DeleteAction (string id);
    }
}
