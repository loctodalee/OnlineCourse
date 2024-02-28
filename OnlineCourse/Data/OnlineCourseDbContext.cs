using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Entity.Order;

namespace OnlineCourse.Data
{
    public class OnlineCourseDbContext : DbContext
    {
        IConfiguration _configuration;

        public OnlineCourseDbContext() { }
        
        public OnlineCourseDbContext(DbContextOptions<OnlineCourseDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserPermissionEntity> UserPermission { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PermissionActionEntity> PermissionAction { get; set; }
        public DbSet<ActEntity> Actions { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<CourseUserEntity> CourseUsers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Local"));
        }
    }
}
