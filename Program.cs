// Import section for PhotoGallery_BackEnd.Models namespace.

// config
global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Security.Claims;
// context
global using PhotoGallery_BackeEnd.Context;
// controller
global using PhotoGallery_BackEnd.Controllers.Test;
// service
global using PhotoGallery_BackEnd.Services.Auth;
// model
global using PhotoGallery_BackEnd.Models.ReportRequest;
global using PhotoGallery_BackEnd.Models.ServiceResponse;
global using PhotoGallery_BackEnd.Models.Tasks;
global using PhotoGallery_BackEnd.Models.Test;
global using PhotoGallery_BackEnd.Models.Users;
global using TaskStatus = PhotoGallery_BackEnd.Models.Tasks.TaskStatus;
global using PhotoGallery_BackEnd.Mapper;
// dtos
global using PhotoGallery_BackEnd.DTOs.InitialComponents;
global using PhotoGallery_BackEnd.DTOs.Tasks;
global using PhotoGallery_BackEnd.DTOs.Users;
// lib
global using Microsoft.Extensions.Configuration;
global using System.Configuration;
global using Newtonsoft.Json;
global using System.Runtime.Serialization;
global using System.Text.Json.Serialization;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.AspNetCore.Http.Features;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Filters;
global using Microsoft.AspNetCore.Authentication.JwtBearer;



// Minimal API section
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// --Add DbContext--

//Code First
builder.Services.AddDbContext<TaskDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BackEndDbConnection");
    options.UseSqlServer(connectionString);
});
// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        }));
//File limit
// Configure the appsettings.json file
var appSettings = builder.Configuration.GetSection("AppSettings");
var maxRequestLength = appSettings.GetValue<long>("MaxRequestLength");
var maxAllowedContentLength = appSettings.GetValue<long>("MaxAllowedContentLength");
var requestTimeoutSeconds = appSettings.GetValue<int>("RequestTimeout:Seconds");
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = maxRequestLength;
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = maxRequestLength;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = maxAllowedContentLength;
});
// Configure AutoMapper mappings
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add Service
//builder.Services.AddScoped<IGetDataService, GetDataService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
/*builder.Services.AddScoped<ICreateTaskService, CreateTaskService>();
builder.Services.AddScoped<IExcuteTaskService, ExcuteTaskService>();
builder.Services.AddScoped<IViewTaskService, ViewTaskService>();
builder.Services.AddScoped<IReportOpService, ReportOpService>();
builder.Services.AddScoped<IExportReportService, ExportReportService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ICustomerDbService, CustomerDbService>();
builder.Services.AddScoped<ITranformService, TranformService>();
*/

// Auth
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = """Standard Authorization header using the Bearer scheme. Example: "bearer {token} " """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddHttpContextAccessor();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole(); // Configure to log to the console
}); 
var app = builder.Build();

//Initial something
// Create a service scope
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    await dbContext.UpdateStatusForStartingProgramAsync();
}

// SWAGGER Section
bool isDevelopment = app.Configuration.GetValue<bool>("IsDevelopment");
if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");
/*app.MapHub<ProgressHub>("/progresshub");*/

app.Run();
