using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AuthService.Config;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Configuration
// --------------------
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"));

var jwtOptions = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtOptions>()!;

// --------------------
// Authentication
// --------------------
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = jwtOptions.Authority;
        options.Audience = jwtOptions.Audience;
        options.RequireHttpsMetadata = false; // local için

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Authority,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };

        // DEBUG & LOG
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("❌ Authentication failed");
                Console.WriteLine(context.Exception);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("✅ Token validated");
                Console.WriteLine($"User: {context.Principal?.Identity?.Name}");
                return Task.CompletedTask;
            }
        };
    });

// --------------------
// Authorization
// --------------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("ADMIN"));
});

// --------------------
// Controllers
// --------------------
builder.Services.AddControllers();

var app = builder.Build();

// --------------------
// Middleware Pipeline
// --------------------
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
