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
global using IAuthRepository = PhotoGallery_BackEnd.Services.Auth.IAuthRepository;
global using PhotoGallery_BackEnd.Services.Auth;
global using PhotoGallery_BackEnd.Services.Gallery;
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
global using PhotoGallery_BackEnd.DTOs.Gallery;
// lib
global using Microsoft.Extensions.Configuration;
global using System.Configuration;
global using Newtonsoft.Json;
global using System.Runtime.Serialization;
global using System.Text.Json.Serialization;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.AspNetCore.Http.Features;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Filters;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.ResponseCompression;
global using System.Security.Cryptography;
global using System.Text;
global using ServiceStack.Auth;
global using PhotoGallery_BackEnd.Models.Users;
global using ServiceStack.Auth;
global using System.Text;

// Minimal API section
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// --Add DbContext--

// Code First
builder.Services.AddDbContext<APIDbContext>(options =>
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

// File limit
// Configure the appsettings.json file
var appSettings = builder.Configuration.GetSection("AppSettings");

// Generate a secure key
var key = new byte[64]; // 512 bits
using (var rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(key);
}

// Store the key securely. You can use a secret manager or store it as an environment variable.
// For demonstration purposes, I'll store it in the appsettings.json.
appSettings["Token"] = Convert.ToBase64String(key);

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

builder.Services.AddHttpContextAccessor();
// Add Service
// builder.Services.AddScoped<IGetDataService, GetDataService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IGallery, Gallery>();
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

builder.Services.AddResponseCompression(options =>
options.MimeTypes = ResponseCompressionDefaults
.MimeTypes
.Concat(new[] { "application/octet-stream" }));

// Configure JWT authentication with the generated key
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});


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

// Initial something
// Create a service scope
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<APIDbContext>();
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
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");
/*app.MapHub<ProgressHub>("/progresshub");*/
app.Run();
