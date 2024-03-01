using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Data.Model.Course;

namespace OnlineCourse.Configuaration
{
    public class TinyMapperBindingConfiguration
    {
        public static void Configure()
        {
            TinyMapper.Bind<List<ActEntity>, List<ActModel>>();
            TinyMapper.Bind<ActModel, ActEntity>();
            TinyMapper.Bind<ActEntity, ActModel>();
            TinyMapper.Bind<RequestCreateActionModel, ActEntity>();
            TinyMapper.Bind<ActEntity, RequestCreateActionModel>();


            TinyMapper.Bind<List<UserEntity>, List<UserModel>>();
            TinyMapper.Bind<RequestCreateUserModel, UserEntity>();
            TinyMapper.Bind<UserEntity, RequestCreateUserModel>();
            TinyMapper.Bind<UserEntity, UserModel>();
            TinyMapper.Bind<UserModel, UserEntity>();

            TinyMapper.Bind<List<PermissionEntity>, List<PermissionModel>>();
            TinyMapper.Bind<PermissionEntity, PermissionModel>();
            TinyMapper.Bind<PermissionModel, PermissionEntity>();
            TinyMapper.Bind<RequestCreatePermissionModel, PermissionEntity>();

            TinyMapper.Bind<List<UserPermissionEntity>, List<UserPermissionModel>>();
            TinyMapper.Bind<UserPermissionEntity, UserPermissionModel>();
            TinyMapper.Bind<UserPermissionModel, UserPermissionEntity>();
            TinyMapper.Bind<RequestCreateUserPerModel, UserPermissionEntity>();

            TinyMapper.Bind<List<PermissionActionEntity>, List<PermissionActionModel>>();
            TinyMapper.Bind<PermissionActionEntity, PermissionActionModel>();
            TinyMapper.Bind<PermissionActionModel, PermissionActionEntity>();
            TinyMapper.Bind<RequestCreatePerActionModel, PermissionActionEntity>();

            TinyMapper.Bind<List<CourseEntity>, List<CourseModel>>();
            TinyMapper.Bind<CourseEntity, CourseModel>();
            TinyMapper.Bind<CourseModel, CourseEntity>();
            TinyMapper.Bind<RequestCreateCourseModel, CourseEntity>();

            TinyMapper.Bind<List<CourseUserEntity>, List<CourseUserModel>>();
            TinyMapper.Bind<CourseUserEntity, CourseUserModel>();
            TinyMapper.Bind<CourseUserModel, CourseUserEntity>();
            TinyMapper.Bind<RequestCreateCourseUserModel, CourseUserEntity>();

            TinyMapper.Bind<List<LessonEntity>, List<LessonModel>>();
            TinyMapper.Bind<LessonEntity, LessonModel>();
            TinyMapper.Bind<LessonModel, LessonEntity>();
            TinyMapper.Bind<RequestCreateLessonModel, LessonEntity>();
        }
    }
}
