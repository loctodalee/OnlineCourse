using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;
using OnlineCourse.Services.Course.Interface;
using System.Data;

namespace OnlineCourse.Services.Course
{
    public class CourseService : ICourseService
    {
        private IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CourseModel>> GetAll()
        {
            try
            {
                var listEntity = await _unitOfWork.CourseRepository.GetAll();
                var model = TinyMapper.Map<List<CourseModel>>(listEntity);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CourseModel> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetSingleById(id);
                if (result != null)
                {

                    if (result == null)
                    {
                        throw new Exception("Course Not found");
                    }
                    var model = TinyMapper.Map<CourseModel>(result);
                    return model;
                } return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CourseModel> CreateCourse(RequestCreateCourseModel model)
        {
            try
            {
                var list = await _unitOfWork.CourseRepository.GetAll();
                var existed = list.Any(x => x.Name == model.Name);
                if (existed)
                {
                    throw new Exception("Course is existed");
                }
                var entity = TinyMapper.Map<CourseEntity>(model);
                await _unitOfWork.CourseRepository.Add(entity);
                _unitOfWork.SaveChanges();
                var resModel = TinyMapper.Map<CourseModel>(entity);
                return resModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCourse(CourseModel model)
        {
            try
            {
                var entity = TinyMapper.Map<CourseEntity>(model);
                await _unitOfWork.CourseRepository.Update(entity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCourse(string id)
        {
            try
            {
                var existed = await _unitOfWork.CourseRepository.GetSingleById(id);
                if (existed == null)
                {
                    throw new Exception("Course not found");
                }
                await _unitOfWork.CourseRepository.Delete(existed);
                _unitOfWork.SaveChanges();
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
