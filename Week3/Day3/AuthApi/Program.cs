using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataProtection();

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentityCore<AppUser>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()                    // enable roles
.AddSignInManager()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();                 // needed for token generation

var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetByteCount(jwtKey) < 32)
    throw new InvalidOperationException("Configure Jwt:Key with a secret of at least 32 bytes.");

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
    ?? throw new InvalidOperationException("Configure Jwt:Issuer.");
var jwtAudience = builder.Configuration["Jwt:Audience"]
    ?? throw new InvalidOperationException("Configure Jwt:Audience.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1),
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.EnsureCreatedAsync();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    foreach (var roleName in new[] { "User", "Admin" })
    {
        if (await roleManager.RoleExistsAsync(roleName))
            continue;

        var result = await roleManager.CreateAsync(new IdentityRole(roleName));
        if (!result.Succeeded)
            throw new InvalidOperationException(
                $"Could not create role '{roleName}': {string.Join(", ", result.Errors.Select(error => error.Description))}");
    }

    var adminEmail = builder.Configuration["SeedAdmin:Email"];
    var adminPassword = builder.Configuration["SeedAdmin:Password"];
    if (!string.IsNullOrWhiteSpace(adminEmail) || !string.IsNullOrWhiteSpace(adminPassword))
    {
        if (!app.Environment.IsDevelopment())
            throw new InvalidOperationException("SeedAdmin credentials may only be configured in Development.");
        if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
            throw new InvalidOperationException("Configure both SeedAdmin:Email and SeedAdmin:Password.");

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin is null)
        {
            admin = new AppUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "Development Admin"
            };
            var createResult = await userManager.CreateAsync(admin, adminPassword);
            if (!createResult.Succeeded)
                throw new InvalidOperationException(
                    $"Could not create development admin: {string.Join(", ", createResult.Errors.Select(error => error.Description))}");
        }

        if (!await userManager.IsInRoleAsync(admin, "Admin"))
        {
            var roleResult = await userManager.AddToRoleAsync(admin, "Admin");
            if (!roleResult.Succeeded)
                throw new InvalidOperationException(
                    $"Could not assign the Admin role: {string.Join(", ", roleResult.Errors.Select(error => error.Description))}");
        }
    }
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();