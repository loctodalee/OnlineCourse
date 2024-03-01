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
        public DbSet<UserCourseLessonProgressEntity> UserCourseLessonProgress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Local"));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserCourseLessonProgressEntity to UserEntity relationship
            modelBuilder.Entity<UserCourseLessonProgressEntity>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCourseLessonProgresses)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // No action on delete

            // UserCourseLessonProgressEntity to CourseEntity relationship
            modelBuilder.Entity<UserCourseLessonProgressEntity>()
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UserCourseLessonProgresses)
                .HasForeignKey(uc => uc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);  // No action on delete

            // UserCourseLessonProgressEntity to LessonEntity relationship
            modelBuilder.Entity<UserCourseLessonProgressEntity>()
                .HasOne(uc => uc.Lesson)
                .WithMany(l => l.UserCourseLessonProgresses)
                .HasForeignKey(uc => uc.LessonId)
                .OnDelete(DeleteBehavior.Restrict);  // No action on delete
        }
    }
}
