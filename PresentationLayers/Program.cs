using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
const string CORS_POLICY = "AllowAll";
// Add services to the container.
#region DI Services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options
             => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
                             builder =>
                             {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

builder.Services.AddTransient<IAdsElonInterface, AdsElonRepository>();
builder.Services.AddTransient<ICategoryInterface, CategoryRepository>();
builder.Services.AddTransient<IChatInterface, ChatRepository>();
builder.Services.AddTransient<IImageInterface, ImageRepository>();
builder.Services.AddTransient<IMessageInterface, MessageRepository>();
builder.Services.AddTransient<IRegionInterface, RegionRepository>();
builder.Services.AddTransient<ISubCategoryInterface, SubCategoryRepository>();
builder.Services.AddTransient<ISubRegionInterface, SubRegionRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubCategoryService, SubCategoryService>();
#endregion

#region Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMepperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region JWT
var secretKey = builder.Configuration.GetSection("JWT:SecretKey").Value;
var key = Encoding.ASCII.GetBytes(secretKey!);
var issuer = builder.Configuration.GetSection("JWT:Issuer").Value;
var audience = builder.Configuration.GetSection("JWT:Audience").Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role
        };
    });

#endregion


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CORS_POLICY);
app.UseAuthorization();

app.MapControllers();

app.Run();
