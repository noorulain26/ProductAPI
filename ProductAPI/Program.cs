using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Interfaces;
using ProductAPI.Application.Services;
using ProductAPI.Application.Validators;
using ProductAPI.WebAPI.Middleware;
using ProductAPI.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services to DI Container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 2. Register Database Context using MyDbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Pure Clean Architecture: Register interface with the concrete implementation
builder.Services.AddScoped<IMyDbContext>(provider =>
    provider.GetRequiredService<MyDbContext>());

// 4. Register Application Services & Validators
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductCreateValidator>();

// 4.5. Register JWT Authentication Settings (Pure Simple Code)
var jwtKey = System.Text.Encoding.ASCII.GetBytes("SuperSecretKeyThatIsVeryLongAndSecure123!");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(jwtKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// 5. Configure HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();

app.Run();
