using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data.Entity.Auth;

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
