using Microsoft.EntityFrameworkCore;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Data;
using TimeSheet.Data.Repositories;
using TimeSheet.Infrastructure.Services;
using TimeSheet.Service.Services;
using TimeSheet.WebAPI.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);
builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IWorkingHourRepository, WorkingHourRepository>();
builder.Services.AddScoped<IWorkingHourService, WorkingHourService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectservice, ProjectService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
