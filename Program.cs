// Import section for PhotoGallery_BackEnd.Models namespace.

// config
global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
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



// Minimal API section
var builder = WebApplication.CreateBuilder(args);

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

app.Run();
