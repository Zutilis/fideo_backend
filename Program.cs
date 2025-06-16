using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Fideo.CourseDbContext;
using Fideo.Models;
using Fideo.Repositories;
using Fideo.Services;
using Fideo.Configurations;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Development
});

// Chargement de la config JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Authentification JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme             = JwtBearerDefaults.AuthenticationScheme; // 👈 important
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = true,
        ValidateAudience         = true,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer              = jwtSettings.Issuer,
        ValidAudience            = jwtSettings.Audience,
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});

// Swagger avec support JWT
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Fideo API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Entrez 'Bearer {token}' dans le champ Authorization"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Services applicatifs
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

// DB EF Core
builder.Services.AddDbContext<BackendContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))
    ));

// Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BackendContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();
app.UseAuthentication(); // ⬅️ obligatoire avant Authorization
app.UseAuthorization();
app.MapControllers();
app.Run();