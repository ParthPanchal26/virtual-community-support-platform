using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VCS.Repositories.Repositories;
using VCS.Services.Services;
using System.Text;
using VCS.Entities.Context;
using VCS.Repositories.Helper;
using VCS.Repositories.IRepositories;
using VCS.Service.IServices;
using VCS.Service.Services;
using VCS.Services.IService;
using VCS.Services.IServices;
using VCS.Services.Service;
using VCS.Repositories;
using VCS.Services;

namespace VCS {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<VCSDbContext>(db =>
                db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Scoped services registration
            builder.Services.AddScoped<JwtService>();

            builder.Services.AddScoped<IAdminUserService, AdminUserService>();
            builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();

            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddScoped<IMissionSkillRepository, MissionSkillRepository>();
            builder.Services.AddScoped<IMissionSkillService, MissionSkillService>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IMissionThemeService, MissionThemeService>();
            builder.Services.AddScoped<IMissionThemeRepository, MissionThemeRepository>();

            builder.Services.AddScoped<ICommonService, CommonService>();
            builder.Services.AddScoped<ICommonRepository, CommonRepository>();

            builder.Services.AddScoped<IMissionService, MissionService>();
            builder.Services.AddScoped<IMissionRepository, MissionRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
