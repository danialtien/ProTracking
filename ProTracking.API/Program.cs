using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Infrastructures.Data;
using ProTracking.Infrastructures.Mappers;
using ProTracking.Infrastructures.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
