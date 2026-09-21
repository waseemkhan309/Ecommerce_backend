
using Ecommerce_backend.Data;
using Ecommerce_backend.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;


namespace Ecommerce_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // register the database context        
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ECommerceDatabaseString")));

            builder.Services.AddApplicationServices();

            var jwtKey = builder.Configuration["Jwt:Key"]!;
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
            .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    };
                }
                );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(errApp =>
            {
                errApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var ex = feature?.Error;
                    var path = feature?.Path;

                    var logger = context.RequestServices.GetRequiredService<ILoggerFactory>()
                                        .CreateLogger("GlobalExceptionHandler");

                    logger.LogError(ex, "Unhandled exception at {Path}", path);

                    var (statusCode, message) = ex switch
                    {
                        ArgumentException => (StatusCodes.Status400BadRequest, ex.Message),
                        UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, ex.Message),
                        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
                    };

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsJsonAsync(new { message, path });
                });
            });


            app.MapControllers();

            app.Run();
        }
    }
}
  