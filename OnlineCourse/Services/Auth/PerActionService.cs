using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;
using System.Data;

namespace OnlineCourse.Services.Auth
{
    public class PerActionService : IPerActionService
    {
        public IUnitOfWork unitOfWork;

        public PerActionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionActionModel>> GetAll()
        {
            try
            {
                var listEntity = await unitOfWork.PerActionRepository.GetAll();
                var validList = listEntity.Where(x => x.IsActive == true).ToList();

                var model = TinyMapper.Map<List<PermissionActionModel>>(validList);

                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PermissionActionModel>> GetByPermissionId(string id)
        {
            try
            {
                var list = await unitOfWork.PerActionRepository.GetAll();
                var listEntity = list.Where(x => x.PermissionId == id && x.IsActive == true).ToList();
                if(listEntity == null)
                {
                    throw new Exception("Not Found");
                }

                var model = TinyMapper.Map<List<PermissionActionModel>>(listEntity);
                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionActionModel> CreatePerAction(RequestCreatePerActionModel model)
        {
            try
            {
                var list = await unitOfWork.PerActionRepository.GetAll();
                var existed = list.Any(x => x.PermissionId == model.PermissionId && x.ActionId == model.ActionId);
                if (existed)
                {
                    throw new Exception("Permission Action is existed");
                }

                var entity = TinyMapper.Map<PermissionActionEntity>(model);
                await unitOfWork.PerActionRepository.Add(entity);
                unitOfWork.SaveChanges();

                var resModel = TinyMapper.Map<PermissionActionModel>(entity);
                return resModel;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeletePerAction(PermissionActionModel model)
        {
            try
            {
                var list = await unitOfWork.PerActionRepository.GetAll();
                var exsited = list.Where(x => x.PermissionId == model.PermissionId && x.ActionId == model.ActionId).FirstOrDefault();
                if (exsited == null)
                {
                    throw new Exception("Not found" + exsited);
                }

                await unitOfWork.PerActionRepository.Delete(exsited);
                unitOfWork.SaveChanges();

            }
            catch (ConstraintException ex)
            {
                throw new Exception("Contraint Key: \n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
