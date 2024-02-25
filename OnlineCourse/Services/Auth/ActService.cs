using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.NewFolder;
using System.Data;

namespace OnlineCourse.Services.Auth
{
    public class ActService : IActService
    {
        private readonly IUnitOfWork unitOfWork;

        public ActService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<List<ActModel>> GetActions()
        {
            try
            {
                var actions = await unitOfWork.ActionRepository.GetAll();
                var validAction = actions.Where(i => i.IsActive == true).ToList();
                var actionModels = TinyMapper.Map<List<ActModel>>(validAction);
                return actionModels;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActModel> CreateAction(RequestCreateActionModel model)
        {
            try
            {
                var actions = await unitOfWork.ActionRepository.GetAll();
                var existed = actions.Any(i => i.ActionCode == model.ActionCode);
                if (existed)
                {
                    throw new Exception("Action is existed !!!");
                }
                var entity = TinyMapper.Map<ActEntity>(model);
                await unitOfWork.ActionRepository.Add(entity);
                unitOfWork.SaveChanges();
                var res = TinyMapper.Map<ActModel>(entity);
                return res;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActModel> GetActionById(string id)
        {
            try
            {
                var existed = await unitOfWork.ActionRepository.GetSingleById(id);
                if (existed == null)
                {
                    throw new Exception("Action not existed !!");
                }
               
                var model = TinyMapper.Map<ActModel>(existed);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActModel> UpdateAction(ActModel model)
        {
            try
            {
                var entity = TinyMapper.Map<ActEntity>(model);
                await unitOfWork.ActionRepository.Update(entity);
                unitOfWork.SaveChanges();
                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAction(string id)
        {
            try
            {
                var existed = await unitOfWork.ActionRepository.GetSingleById(id);
                if(existed == null)
                {
                    throw new Exception("Action not found");
                }
                await unitOfWork.ActionRepository.Delete(existed);
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
