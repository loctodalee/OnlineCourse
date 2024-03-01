using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Services.Auth
{
    public class UserPerService : IUserPerService
    {
        private IUnitOfWork _unitOfWork;
        public UserPerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserPermissionModel>> GetAll()
        {
            try
            {
                var list = await _unitOfWork.UserPerRepository.GetAll();
                var validList = list.Where(x => x.IsActive).ToList();

                var model = TinyMapper.Map<List<UserPermissionModel>>(validList);
                return model;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserPermissionModel>> GetByUserId(string id)
        {
            try
            {
                var list = await _unitOfWork.UserPerRepository.GetAll();
                var listEntity = list.Where(x => x.UserId == id && x.IsActive == true).ToList();
                if (listEntity == null)
                {
                    throw new Exception("Not found");
                }
                var model = TinyMapper.Map<List<UserPermissionModel>>(listEntity);
                return model;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserPermissionModel> CreateUserPer(RequestCreateUserPerModel model)
        {
            try
            {
                var list = await _unitOfWork.UserPerRepository.GetAll();
                var existed = list.Any(x => x.UserId == model.UserId && x.PermissionId == model.PermissionId);
                if (existed)
                {
                    throw new Exception("Existed");
                }
                var entity = TinyMapper.Map<UserPermissionEntity>(model);
                await _unitOfWork.UserPerRepository.Add(entity);
                _unitOfWork.SaveChanges();
                var resModel = TinyMapper.Map<UserPermissionModel>(entity);
                return resModel;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeleteUserPer(UserPermissionModel model)
        {
            try
            {
                var list = await _unitOfWork.UserPerRepository.GetAll();
                var existed = list
                    .Where(x => x.UserId == model.UserId && x.PermissionId == model.PermissionId && x.IsActive == true).FirstOrDefault();
                if(existed == null)
                {
                    throw new Exception("Not found");
                }
                await _unitOfWork.UserPerRepository.Delete(existed);
                _unitOfWork.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
