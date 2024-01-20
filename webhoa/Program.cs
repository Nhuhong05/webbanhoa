using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.Security.Principal;
using System.Text;
using webhoa.Entities;
using webhoa.Helpers;
using webhoa.Middleware_;
using webhoa.Repository;
using webhoa.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebbanhoaContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("webbanhoa")));
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(ApplicationAutoMapper));
builder.Services.AddScoped<IFlowerRepository, HoaRepository>();
builder.Services.AddScoped<ILoaiHoaRepository, LoaiHoaRepsitory>();
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<WebbanhoaContext>().AddDefaultTokenProviders();
//builder.Services.AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JWT: ValidAudience"],
//        ValidIssuer = builder.Configuration["JWT: ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
//        (builder.Configuration["JWT:Secret"]))
//    };
//});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredUniqueChars = 4;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<WebbanhoaContext>()
  .AddDefaultTokenProviders();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
});

builder.Services.AddTransient<TokenService>();

builder.Services.AddHttpLogging(loggin =>
{
    loggin.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All
  | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseHeaders;
});
var app = builder.Build();
app.UseRateLimiter();
app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseReqResLogging();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

// add custom middleware

app.Run();
