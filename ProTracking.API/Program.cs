using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Data;
using ProTracking.Infrastructures.Mappers;
using ProTracking.Infrastructures.Repository;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ProTracking.Infrastructures.CustomValidation;
using ProTracking.Domain.CustomValidation;
using ProTracking.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ODataConventionModelBuilder oDataBuilder = new ODataConventionModelBuilder();
/*oDataBuilder.EntitySet<TodoDTO>("Todos");
oDataBuilder.EntitySet<ProjectDTO>("Projects");*/
builder.Services.AddControllers().AddOData(option => option.Select()
    .Filter()
    .Count()
    .OrderBy()
    .Expand()
    .AddRouteComponents("", oDataBuilder.GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Them CORS cho tat ca moi nguoi deu xai duoc apis
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

/*builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; // Use the Google authentication scheme
})
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
        options.ClientId = builder.Configuration["Google:ClientId"];
        options.ClientSecret = builder.Configuration["Google:ClientSecret"];
        options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        options.CallbackPath = "/signin-google";
    });*/

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});


builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ProTraking",
        Description = "Build application for manage projects",
        /*Contact = new OpenApiContact
        {
            Name = "danialtien",
            Email = "tiendoit20@gmail.com",
            Url = new Uri("https://www.facebook.com/nguyendinhtien123/")
        },
        License = new OpenApiLicense
        {
            Name = "danialtien License",
        },
        Version = "v1"*/
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
}).AddSwaggerGen();

/*---Start ---Apply Dependency Injection*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Services
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IProjectParticipantService, ProjectParticipantService>();
builder.Services.AddTransient<IChildTaskService, ChildTaskService>();
builder.Services.AddTransient<ILabelService, LabelService>();
builder.Services.AddTransient<IAccountTypeService, AccountTypeService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();


// Repository
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<IProjectRepo, ProjectRepo>();
builder.Services.AddTransient<ITodoRepo, TodoRepo>();
builder.Services.AddTransient<IProjectParticipantRepo, ProjectParticipantRepo>();
builder.Services.AddTransient<IChildTaskRepo, ChildTaskRepo>();
builder.Services.AddTransient<ILabelRepo, LabelRepo>();
builder.Services.AddTransient<IAccountTypeRepo, AccountTypeRepo>();
builder.Services.AddTransient<ICommentRepo, CommentRepo>();
builder.Services.AddTransient<IPaymentRepo, PaymentRepo>();
builder.Services.AddTransient<ITransactionHistoryRepo, TransactionHistoryRepo>();




// Mapper
builder.Services.AddAutoMapper(typeof(Program));
var serviceProvider = builder.Services.BuildServiceProvider();
var autoMapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperProfile(serviceProvider.GetRequiredService<IUnitOfWork>())));
IMapper mapper = autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

/*---End ---Apply Dependency Injection*/

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProTracking");
    });
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
