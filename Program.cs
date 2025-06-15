using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Fideo.CourseDbContext;
using Fideo.Models;
using Fideo.Repositories;
using Fideo.Services;
using Fideo.Configurations;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Production
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

Console.WriteLine("Loaded connection string:");
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Not found");

// Ajouter les services nécessaires
builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost", policy => {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<AppointmentStatusRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<AvailableSlotRepository>();
builder.Services.AddScoped<BusinessRepository>();
builder.Services.AddScoped<OfferRepository>();
builder.Services.AddScoped<PointsRepository>();
builder.Services.AddScoped<ReviewRepository>();

builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<AppointmentStatusService>();
builder.Services.AddScoped<AvailableSlotService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<BusinessService>();
builder.Services.AddScoped<OfferService>();
builder.Services.AddScoped<PointsService>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddDbContext<BackendContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))
    ));

builder.Services.AddControllersWithViews();

// builder.Services.AddDbContext<CourseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BackendContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();