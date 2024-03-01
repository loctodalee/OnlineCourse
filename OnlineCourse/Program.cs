using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nelibur.ObjectMapper;
using OnlineCourse.Configuaration;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Entity.Order;
using OnlineCourse.Data.Model;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Data.Model.Email;
using OnlineCourse.Repository;
using OnlineCourse.Repository.Auth;
using OnlineCourse.Repository.Course;
using OnlineCourse.Repository.Order;
using OnlineCourse.Services.Auth;
using OnlineCourse.Services.Auth.Interface;
using OnlineCourse.Services.Auth.NewFolder;
using OnlineCourse.Services.Course;
using OnlineCourse.Services.Course.Interface;
using OnlineCourse.Services.Email;
using OnlineCourse.Services.Email.Interface;
using OnlineCourse.Services.Order;
using OnlineCourse.Services.Payment.Interface;
using OnlineCourse.Services.Payment;
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
builder.Services.AddTransient<IRepository<UserCourseLessonProgressEntity>, UserCourseLessonProgressRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IActService, ActService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IUserPerService, UserPerService>();
builder.Services.AddScoped<IPerActionService, PerActionService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseUserService, CourseUserService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICourseService, CourseService>();
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
TinyMapperBindingConfiguration.Configure();


//config momo
builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();


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
