using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Infrastructures.Data;
using ProTracking.Infrastructures.Mappers;
using ProTracking.Infrastructures.Repository;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Them CORS cho tat ca moi nguoi deu xai duoc apis
builder.Services.AddCors(options
        => options.AddDefaultPolicy(policy
            => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; // Use the Google authentication scheme
})
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
        options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
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
}).AddSwaggerGen();

/*---Start ---Apply Dependency Injection*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddTransient<ICustomerService, CustomerService>();


// Repository
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();


// Mapper
var autoMapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperProfile()));
IMapper mapper = autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

/*---End ---Apply Dependency Injection*/

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
