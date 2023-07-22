﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Text;
using TasleemDelivery.Data;
using TasleemDelivery.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", policybuilder =>
        //policybuilder.WithOrigins(builder.Configuration.GetSection("Cors").Value).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
        policybuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );


});
builder.Services.AddDbContext<Context>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
              .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
              .EnableSensitiveDataLogging());

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<Context>()
              .AddDefaultTokenProviders();
// Add services to the container.

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // Requires at least one digit
    options.Password.RequireLowercase = true; // Requires at least one lowercase letter
    options.Password.RequireUppercase = false; // Requires at least one lowercase letter

    options.Password.RequireNonAlphanumeric = false;


    // options.Password.RequireNonAlphanumeric = true; // Requires at least one non-alphanumeric character
    options.Password.RequiredLength = 8;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ اهعبتثجحخدذرزسشصضطظعغفقكلمنهويءآأؤإئىة";

    // Minimum password length
    //  options.Password.RequiredUniqueChars = 6; // Minimum number of unique characters in a password
});

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))

        };


    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
});

builder.Services.AddSwaggerGen(swagger =>
    {
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ASP.NET 5 Web API",
        Description = " ITI Project"
    });

        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
        });
        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
new string[] { }

                    }
                });
    });









var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");//add header response Asscee-original-m
app.UseAuthentication();//AddAuth==>jwt
app.UseAuthorization();

app.MapControllers();

app.Run();
