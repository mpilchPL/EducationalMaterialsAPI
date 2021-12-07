using EducationalMaterialsAPI.Controllers.Authentication;
using EducationalMaterialsAPI.Data.DAL;
using EducationalMaterialsAPI.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EduMaterialsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EduMaterialsDbConnection")));

#region JWT Auth

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSingleton<IJwtAuth>(new JwtAuth(builder.Configuration["Jwt:Key"]));

#endregion

builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
builder.Services.AddControllers()
    .AddNewtonsoftJson(s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EducationalMaterialsAPI",
        Description = "An ASP.NET Core Web API for managing a database of series",
        Version = "v1"
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Educational Materials API");
});
    
app.Run();
