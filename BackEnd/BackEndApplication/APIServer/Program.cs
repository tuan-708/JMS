using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using APIServer.Repositories;
using APIServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace APIServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var allowFE = "_AllowFrontEndClient";

            //add Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowFE,
                                  policy =>
                                  {
                                      policy.WithOrigins(builder.Configuration.GetValue<string>("FE_Port"))
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            // Add services to the container.

            builder.Services.AddControllers();

            //JWT
            builder.Services.AddAuthentication(
                x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<JMSDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("JobConstr")));

            configurationInterfce(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(allowFE);

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void configurationInterfce(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IBaseRepository<JobPost>, JobRepository>();
            builder.Services.AddTransient<IJobService, JobService>();
        }
    }
}