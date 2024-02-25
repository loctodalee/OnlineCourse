using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Repository.Auth;

namespace OnlineCourse.Repository
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }
        IRepository<PermissionEntity> PermissionRepository { get; }
        IRepository<ActEntity> ActionRepository { get; }
        IRepository<UserPermissionEntity> UserPerRepository { get; }
        IRepository<PermissionActionEntity> PerActionRepository { get; }
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
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
