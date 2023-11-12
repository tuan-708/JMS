using APIServer.DTO.EntityDTO;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;
using APIServer.Repositories;
using APIServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

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

            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
            builder.Services.AddDbContext<JMSDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("JobConstr"));
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

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

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.Run();
        }

        private static void configurationInterfce(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IRecuirterService, RecuirterService>();
            builder.Services.AddTransient<IRecuirterRepository, RecuirterRepository>();
            builder.Services.AddTransient<IJobRepository, JobRepository>();
            builder.Services.AddTransient<IJobService, JobService>();
            builder.Services.AddTransient<ICurriculumVitaeRepository, CurriculumVitaeRepository>();
            builder.Services.AddTransient<ICurriculumVitaeService, CurriculumVitaeService>();
            builder.Services.AddTransient<IBaseRepository<Level>, LevelRepository>();
            builder.Services.AddTransient<IBaseRepository<Company>, CompanyRepository>();
            builder.Services.AddTransient<ICompanyService, CompanyService>();
            builder.Services.AddTransient<IBaseRepository<Category>, CategoryRepository>();
            builder.Services.AddTransient<IBaseRepository<EmploymentType>, EmploymentTypeRepository>();
            builder.Services.AddTransient<ICVMatchingRepository, CVMatchingRepository>();
            builder.Services.AddTransient<IBaseRepository<EmployeeInCompany>, EmployeeInCompanyRepository>();
            builder.Services.AddTransient<IImageService, ImageService>();
            builder.Services.AddTransient<ICandidateService, CandidateService>();
            builder.Services.AddTransient<IBaseRepository<Gender>, GenderRepository>();
            builder.Services.AddTransient<IRecurterCommon, RecuirterCommonService>();
            builder.Services.AddTransient<ICandidateRepository, CandidateRepository>();
            builder.Services.AddTransient<IBaseRepository<Slider>, SliderRepository>();
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddTransient<IRegisterService, RegisterService>();
        }
    }
}