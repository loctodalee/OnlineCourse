using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Course.Interface;

namespace OnlineCourse.Services.Course
{
    public class LessonService : ILessonService
    {
        private IUnitOfWork _unitOfWork;
        public LessonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LessonModel>> GetAll()
        {
            try
            {
                var list = await _unitOfWork.LessonRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true).ToList();
                var model = TinyMapper.Map<List<LessonModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LessonModel>> GetAllLessonByCourseId(string courseId)
        {
            try
            {
                var list = await _unitOfWork.LessonRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.CourseId == courseId).ToList();
                var model = TinyMapper.Map<List<LessonModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LessonModel?> GetLessonById(string id)
        {
            try
            {
                var entity = await _unitOfWork.LessonRepository.GetSingleById(id);
                if (entity != null)
                {
                    var model = TinyMapper.Map<LessonModel>(entity);
                    return model;
                } return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LessonModel> CreateLesson(string priviousLessonId, RequestCreateLessonModel model)
        {
            try
            {
                var entity = TinyMapper.Map<LessonEntity>(model);

                if (priviousLessonId == null)
                {
                    //cap nhat begin lesson cho course
                    var course = await _unitOfWork.CourseRepository.GetSingleById(model.CourseId);
                    course.BeginLessonId = entity.Id;
                    await _unitOfWork.CourseRepository.Update(course);
                }
                else
                {
                    var previousLesson = await _unitOfWork.LessonRepository.GetSingleById(priviousLessonId);

                    //cap nhap lesson tiep theo cho lesson truoc do
                    previousLesson.NextLessonId = entity.Id;
                    await _unitOfWork.LessonRepository.Update(previousLesson);
                }

                //them moi lesson 
                await _unitOfWork.LessonRepository.Add(entity);

                _unitOfWork.SaveChanges();

                var resModel = TinyMapper.Map<LessonModel>(entity);
                return resModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LessonModel> UpdateLesson(LessonModel model)
        {
            try
            {
                var exsited = await _unitOfWork.LessonRepository.GetSingleById(model.Id);
                if (exsited == null)
                {
                    throw new Exception("Not found");
                }
                var entity = TinyMapper.Map<LessonEntity>(model);
                await _unitOfWork.LessonRepository.Update(entity);
                _unitOfWork.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteLesson(string id)
        {
            try
            {
                var exsited = await _unitOfWork.LessonRepository.GetSingleById(id);

                if (exsited == null)
                {
                    throw new Exception("Not found");
                }

                await _unitOfWork.LessonRepository.Delete(exsited);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
