using CustomerManagement.EmployeeManagement.Models.Repositories.Implementations;
using CustomerManagement.EmployeeManagement.Models.Repositories.Interfaces;
using EmployeeManagement.Models.Repositories.Implementations;
using EmployeeManagement.Models.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
builder.Services.AddSingleton<ICustomerRepository, MockCustomerRepository>();
builder.Services.AddSwaggerGen();

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

//app.UseMvcWithDefaultRoute();
app.MapControllers();
app.Run();
