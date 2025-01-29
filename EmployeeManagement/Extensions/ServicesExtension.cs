using EmployeeManagement.Data;
using EmployeeManagement.Models.IRepository;
using EmployeeManagement.Models.Repositories.Implemintations;
using EmployeeManagement.Models.Repositories.Interfaces;
using EmployeeManagement.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

namespace EmployeeManagement.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureController(this IServiceCollection services)
        {
            services.AddControllers().AddXmlSerializerFormatters();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void ConfigureDBContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<AppDBContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("EmployeeDB")));
        }

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var JwtSettings = configuration.GetSection("Jwt");
            var key = Environment.GetEnvironmentVariable("KEY");
          
            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(O =>
          {
              O.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateLifetime = true,
                  ValidateAudience = false,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = JwtSettings.GetSection("Issuer").Value,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))

              };
         });

        }
    }
}
