
using BookApi.Data.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace BookApi {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            byte[] secretBytes = new byte[64];
            using (var random = RandomNumberGenerator.Create()) {
                random.GetBytes(secretBytes);
            }

            string secretKey = Convert.ToBase64String(secretBytes);
                

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Use JWT token
                .AddJwtBearer(options => { // rules for how jet will be validate
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true, // token issued by trusted source
                        ValidateAudience = false, // skipping check who the token is for
                        ValidateLifetime = true, // rejecting expired tokens
                        ValidateIssuerSigningKey = true, // check if token signature is valid or not using secret key
                        ValidIssuer = "ValidateIssuer", // name of expected issuer of token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // secret key to validate token
                    };
                });

            builder.Services.AddAuthorization(); // enable [Authorize] attribute

            builder.Services.AddIdentityApiEndpoints<IdentityUser>(options => { // adds endpoints, password configurations
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<BookDbContext>() // using postgres
                .AddDefaultTokenProviders(); // provide support for passwd reset, email varification, 2-Factor token

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<IdentityUser>(); // display the Identity'UI

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
