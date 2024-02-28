using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nelibur.ObjectMapper;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Entity.Order;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Email;
using OnlineCourse.Repository;
using OnlineCourse.Repository.Auth;
using OnlineCourse.Repository.Course;
using OnlineCourse.Repository.Order;
using OnlineCourse.Services.Auth;
using OnlineCourse.Services.Auth.Interface;
using OnlineCourse.Services.Auth.NewFolder;
using OnlineCourse.Services.Email;
using OnlineCourse.Services.Email.Interface;
using OnlineCourse.Util;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var securityKey = builder.Configuration.GetSection("SecurityKey").ToString();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

//SendMailConfig
IConfiguration configuration = builder.Configuration;
EmailSettingsModel.Instance = configuration.GetSection("EmailSettings").Get<EmailSettingsModel>();

// OnlineCourseDbContext
var connectionString = builder.Configuration.GetConnectionString("Local");
builder.Services.AddDbContext<OnlineCourseDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add DI   
builder.Services.AddTransient<IRepository<UserEntity>, UserRepository>();
builder.Services.AddTransient<IRepository<PermissionEntity>, PermissionRepository>();
builder.Services.AddTransient<IRepository<ActEntity>, ActRepository>();
builder.Services.AddTransient<IRepository<UserPermissionEntity>, UserPerRepository>();
builder.Services.AddTransient<IRepository<PermissionActionEntity>, PerActionRepository>();
builder.Services.AddTransient<IRepository<RefreshTokens>, RefreshTokensRepository>();
builder.Services.AddTransient<IRepository<CourseEntity>, CourseRepository>();
builder.Services.AddTransient<IRepository<CourseUserEntity>, CourseUserRepository>();
builder.Services.AddTransient<IRepository<OrderEntity>, OrderRepository>();
builder.Services.AddTransient<IRepository<LessonEntity>, LessonRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IActService, ActService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IUserPerService, UserPerService>();
builder.Services.AddScoped<IPerActionService, PerActionService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddSingleton<IUtilService, UtilService>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(o =>
{
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
    };
});
//Tiny mapper
TinyMapper.Bind<List<ActEntity>, List<ActModel>>();
TinyMapper.Bind<ActModel, ActEntity>();
TinyMapper.Bind<ActEntity, ActModel>();
TinyMapper.Bind<RequestCreateActionModel, ActEntity>();
TinyMapper.Bind<ActEntity,RequestCreateActionModel>();


TinyMapper.Bind<List<UserEntity>, List<UserModel>>();
TinyMapper.Bind<RequestCreateUserModel, UserEntity>();
TinyMapper.Bind<UserEntity, RequestCreateUserModel>();
TinyMapper.Bind<UserEntity, UserModel>();
TinyMapper.Bind<UserModel, UserEntity>();

TinyMapper.Bind<List<PermissionEntity>, List<PermissionModel>>();
TinyMapper.Bind<PermissionEntity, PermissionModel>();
TinyMapper.Bind<PermissionModel, PermissionEntity>();
TinyMapper.Bind<RequestCreatePermissionModel,  PermissionEntity>();

TinyMapper.Bind<List<UserPermissionEntity>, List<UserPermissionModel>>();
TinyMapper.Bind<UserPermissionEntity, UserPermissionModel>();
TinyMapper.Bind<UserPermissionModel, UserPermissionEntity>();
TinyMapper.Bind<RequestCreateUserPerModel, UserPermissionEntity>();

TinyMapper.Bind<List<PermissionActionEntity>, List<PermissionActionModel>>();
TinyMapper.Bind<PermissionActionEntity, PermissionActionModel>();
TinyMapper.Bind<PermissionActionModel, PermissionActionEntity>();
TinyMapper.Bind<RequestCreatePerActionModel, PermissionActionEntity>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
