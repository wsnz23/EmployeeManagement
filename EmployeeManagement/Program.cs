using CustomerManagement.EmployeeManagement.Models.Repositories.Implementations;
using CustomerManagement.EmployeeManagement.Models.Repositories.Interfaces;
using EmployeeManagement.Data;
using EmployeeManagement.Extensions;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.IRepository;
using EmployeeManagement.Models.Repositories.Implementations;
using EmployeeManagement.Models.Repositories.Implemintations;
using EmployeeManagement.Models.Repositories.Interfaces;
using EmployeeManagement.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureController();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
//builder.Services.AddScoped<IDepartmentRepository, SqlEmployeeRepository>();
builder.Services.AddSingleton<ICustomerRepository, MockCustomerRepository>();
builder.Services.ConfigureAppServices();
builder.Services.ConfigureAppServices();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureDBContext(builder.Configuration);

builder.Services.AddIdentity<APIUser , IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
    developerExceptionPageOptions.SourceCodeLineCount = 1;
    app.UseDeveloperExceptionPage(developerExceptionPageOptions);

    app.UseSwagger();
    app.UseSwaggerUI();
}

//FileServerOptions options = new FileServerOptions();
//options.DefaultFilesOptions.DefaultFileNames.Clear();
//options.DefaultFilesOptions.DefaultFileNames.Add("foo.html");


//app.UseFileServer(options);

app.UseStaticFiles();
app.UseAuthentication();
//app.UseMvcWithDefaultRoute();
app.MapControllers();
app.Run();
