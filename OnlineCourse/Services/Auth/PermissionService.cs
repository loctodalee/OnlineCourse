using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;
using System.Data;

namespace OnlineCourse.Services.Auth
{
    public class PermissionService : IPermissionService
    {
        private IUnitOfWork unitOfWork;
        public PermissionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionModel>> GetPermissionsAsync()
        {
            try
            {
                var entity = await unitOfWork.PermissionRepository.GetAll();
                var validEntity = entity.Where(x => x.IsActive == true).ToList();

                var model = TinyMapper.Map<List<PermissionModel>>(validEntity);
                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionModel> GetPermissionByIdAsync(string id)
        {
            try
            {
                var entity = await unitOfWork.PermissionRepository.GetSingleById(id);
                if (entity == null || entity.IsActive == false)
                    throw new Exception("Not found");
                var model = TinyMapper.Map<PermissionModel>(entity);
                return model;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public async Task<PermissionModel> CreatePermission(RequestCreatePermissionModel model)
        {
            try
            {
                var list = await unitOfWork.PermissionRepository.GetAll();
                var existed = list.Any(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim());
                Console.WriteLine("Existed: " +existed);           
                if(existed)
                {
                    throw new Exception("Permission is existed");
                }
                var entity = TinyMapper.Map<PermissionEntity>(model);
                await unitOfWork.PermissionRepository.Add(entity);
                unitOfWork.SaveChanges();
                var resModel = TinyMapper.Map<PermissionModel>(entity);
                return resModel;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePermission(PermissionModel model)
        {
            try
            {
                var entity = TinyMapper.Map<PermissionEntity>(model);
                await unitOfWork.PermissionRepository.Update(entity);
                unitOfWork.SaveChanges();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletePermissionAsync(string id)
        {
            try
            {
                var existed = await unitOfWork.PermissionRepository.GetSingleById(id);
                if (existed == null)
                {
                    throw new Exception("Permission not found");
                }
                await unitOfWork.PermissionRepository.Delete(existed);
            }
            catch (ConstraintException ex)
            {
                throw new Exception("Contraint: \n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
