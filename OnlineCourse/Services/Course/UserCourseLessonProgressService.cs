using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Course.Interface;

namespace OnlineCourse.Services.Course
{
    public class UserCourseLessonProgressService : IUserCourseLessonProgressService
    {
        private IUnitOfWork _unitOfWork;
        public UserCourseLessonProgressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<UserCourseLessonProgressModel>> GetAll()
        {
            try
            {
                var list = await _unitOfWork.UserCourseLessonProgressRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true).ToList();

                var model = TinyMapper.Map<List<UserCourseLessonProgressModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserCourseLessonProgressModel>> GetByUserId(string id)
        {
            try
            {
                var list = await _unitOfWork.UserCourseLessonProgressRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.UserId == id).ToList();

                if(validList == null)
                {
                    throw new Exception("Not found");
                }
                var model = TinyMapper.Map<List<UserCourseLessonProgressModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserCourseLessonProgressModel>> GetByCourseId(string id)
        {
            try
            {
                var list = await _unitOfWork.UserCourseLessonProgressRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.CourseId == id).ToList();

                if (validList == null)
                {
                    throw new Exception("Not found");
                }
                var model = TinyMapper.Map<List<UserCourseLessonProgressModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserCourseLessonProgressModel>> GetByLessonId(string id)
        {
            try
            {
                var list = await _unitOfWork.UserCourseLessonProgressRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.LessonId == id).ToList();

                if (validList == null)
                {
                    throw new Exception("Not found");
                }
                var model = TinyMapper.Map<List<UserCourseLessonProgressModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCourseLessonProgressModel> CreateBeginProgress(RequestCreateUserCourseLessonProgressModel model)
        {
            try
            {
                var list = await _unitOfWork.UserCourseLessonProgressRepository.GetAll();
                var exsited = list.Any(x => x.UserId == model.UserId && x.CourseId == model.CourseId && x.IsActive == true);
                if (exsited)
                {
                    throw new Exception("Progress is exsited");
                }

                var entity = TinyMapper.Map<UserCourseLessonProgressEntity>(model);
                var course = await _unitOfWork.CourseRepository.GetSingleById(model.CourseId);
                if (course.BeginLessonId == null)
                {
                    throw new Exception("This course is still recording");
                }

                entity.LessonId = course.BeginLessonId;
                await _unitOfWork.UserCourseLessonProgressRepository.Add(entity);

                var res = TinyMapper.Map<UserCourseLessonProgressModel>(entity);
                _unitOfWork.SaveChanges();
                return res;
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task UpdateProgress(UserCourseLessonProgressModel model)
        {
            try
            {

                // cap nhat IsComplete = true
                var entity = TinyMapper.Map<UserCourseLessonProgressEntity>(model);
                await _unitOfWork.UserCourseLessonProgressRepository.Update(entity);

                // Tao progress moi

                var lesson = await _unitOfWork.LessonRepository.GetSingleById(model.LessonId);
                var newEntity = new UserCourseLessonProgressEntity
                {
                    CourseId = model.CourseId,
                    UserId = model.UserId,
                    LessonId = lesson.NextLessonId,
                    IsComplete = false
                };
                await _unitOfWork.UserCourseLessonProgressRepository.Add(newEntity);

                _unitOfWork.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
