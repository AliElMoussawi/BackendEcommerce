using BackendEcommerce.Controllers;
using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using BackendEcommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var str = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(str, ServerVersion.AutoDetect(str)));
  
builder.Services.AddControllers();
builder.Services.AddScoped<ProductRepository, ProductService>();
builder.Services.AddScoped<UserRepository, UserService>();
builder.Services.AddScoped<SessionRepository, SessionService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {   ValidateActor=true,
        ValidateIssuerSigningKey=true,
        ValidateLifetime= true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
