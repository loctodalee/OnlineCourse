using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Entity.Order;
using OnlineCourse.Repository.Auth;
using OnlineCourse.Repository.Course;
using OnlineCourse.Repository.Order;

namespace OnlineCourse.Repository
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }
        IRepository<PermissionEntity> PermissionRepository { get; }
        IRepository<ActEntity> ActionRepository { get; }
        IRepository<UserPermissionEntity> UserPerRepository { get; }
        IRepository<PermissionActionEntity> PerActionRepository { get; }
        IRepository<RefreshTokens> RefreshTokensRepository { get; }
        IRepository<CourseEntity> CourseRepository { get; }
        IRepository<CourseUserEntity> CourseUserRepository { get; }
        IRepository<OrderEntity> OrderRepository { get; }
        IRepository<LessonEntity> LessonRepository { get; }
        IRepository<UserCourseLessonProgressEntity> UserCourseLessonProgressRepository { get;}
        void SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineCourseDbContext db;
        private UserRepository _userRepository;
        private PermissionRepository _permissionRepository;
        private ActRepository _actionRepository;
        private UserPerRepository _userPerRepository;
        private PerActionRepository _perActionRepository;
        private RefreshTokensRepository _refreshTokensRepository;
        private CourseRepository _courseRepository;
        private CourseUserRepository _courseUserRepository;
        private OrderRepository _orderRepository;
        private LessonRepository _lessonRepository;
        private UserCourseLessonProgressRepository _userCourseLessonProgressRepository;

        public UnitOfWork(OnlineCourseDbContext context)
        {
            this.db = context;
        }

        private IRepository<UserEntity> userRepository;
        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if(userRepository == null)
                {
                    _userRepository = new UserRepository(db);
                }
                return this._userRepository;
            }
        }

        private IRepository<PermissionEntity> permissionRepository;
        public IRepository<PermissionEntity> PermissionRepository
        {
            get
            {
                if(permissionRepository == null)
                {
                    _permissionRepository = new PermissionRepository(db);
                }
                return this._permissionRepository;
            }
        }

        private IRepository<ActEntity> actionRepository;
        public IRepository<ActEntity> ActionRepository
        {
            get
            {
                if(actionRepository == null)
                {
                    _actionRepository = new ActRepository(db);
                }
                return this._actionRepository;
            }
        }

        private IRepository<UserPermissionEntity> userPerRepository;
        public IRepository<UserPermissionEntity> UserPerRepository
        {
            get
            {
                if( userPerRepository == null)
                {
                    _userPerRepository = new UserPerRepository(db);
                }
                return this._userPerRepository;
            }
        }

        private IRepository<PermissionActionEntity> perActionRepository;
        public IRepository<PermissionActionEntity> PerActionRepository
        {
            get
            {
                if(perActionRepository == null)
                {
                    _perActionRepository = new PerActionRepository(db);
                }
                return this._perActionRepository;
            }
        }

        private IRepository<RefreshTokens> refreshTokensRepository;
        public IRepository<RefreshTokens> RefreshTokensRepository
        {
            get
            {
                if(refreshTokensRepository == null)
                {
                    _refreshTokensRepository = new RefreshTokensRepository(db);
                }
                return this._refreshTokensRepository;
            }
        }

        private IRepository<CourseEntity> courseRepository;
        public IRepository<CourseEntity> CourseRepository
        {
            get
            {
                if(courseRepository == null)
                {
                    _courseRepository = new CourseRepository(db);
                }
                return this._courseRepository;
            }
        }
        
        private IRepository<CourseUserEntity> courseUserRepository;
        public IRepository<CourseUserEntity> CourseUserRepository
        {
            get
            {
                if (courseUserRepository == null)
                {
                    _courseUserRepository = new CourseUserRepository(db);
                }
                return this._courseUserRepository;
            }
        }

        private IRepository<OrderEntity> orderRepository;
        public IRepository<OrderEntity> OrderRepository
        {
            get
            {
                if(orderRepository == null)
                {
                    _orderRepository = new OrderRepository(db);
                }
                return this._orderRepository;
            }
        }

        private IRepository<LessonEntity> lessonRepository;
        public IRepository<LessonEntity> LessonRepository
        {
            get
            {
                if(lessonRepository == null)
                {
                    lessonRepository = new LessonRepository(db);
                }
                return this._lessonRepository;
            }
        }

        private IRepository<UserCourseLessonProgressEntity> userCourseLessonProgressRepository;
        public IRepository<UserCourseLessonProgressEntity> UserCourseLessonProgressRepository
        {
            get
            {
                if(userCourseLessonProgressRepository == null)
                {
                    userCourseLessonProgressRepository = new UserCourseLessonProgressRepository(db);
                }
                return this._userCourseLessonProgressRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
