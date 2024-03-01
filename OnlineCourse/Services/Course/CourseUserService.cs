using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Course.Interface;
using System.Data;

namespace OnlineCourse.Services.Course
{
    public class CourseUserService : ICourseUserService
    {
        private IUnitOfWork _unitOfWork;
        public CourseUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CourseUserModel>> GetAll()
        {
            try
            {
                var list = await _unitOfWork.CourseUserRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true).ToList();
                if(validList == null)
                {
                    throw new Exception("Not found");
                }
                var result = TinyMapper.Map<List<CourseUserModel>>(validList);
                return result;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CourseUserModel>> GetByUserId(string id)
        {
            try
            {
                var list = await _unitOfWork.CourseUserRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.UserId == id).ToList();
                if (validList == null)
                {
                    throw new Exception("Not found");
                }
                var result = TinyMapper.Map<List<CourseUserModel>>(validList);
                return result;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CourseUserModel> CreateCourseUser(RequestCreateCourseUserModel model)
        {
            try
            {
                var list = await _unitOfWork.CourseUserRepository.GetAll();
                var existed = list.Any(x => x.UserId == model.UserId && x.CourseId == model.CourseId);
                if (existed)
                {
                    throw new Exception("Exsited");
                }

                var entity = TinyMapper.Map<CourseUserEntity>(model);
                await _unitOfWork.CourseUserRepository.Add(entity);

                _unitOfWork.SaveChanges();
                var resModel = TinyMapper.Map<CourseUserModel>(entity);
                return resModel;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCourseUser(CourseUserModel model)
        {
             try
            {
                var list = await _unitOfWork.CourseUserRepository.GetAll();
                var exsited = list.Where(x => x.CourseId == model.CourseId && x.UserId == model.UserId).FirstOrDefault();
                if (exsited == null)
                {
                    throw new Exception("Not found");
                }

                await _unitOfWork.CourseUserRepository.Delete(exsited);
                _unitOfWork.SaveChanges();

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
