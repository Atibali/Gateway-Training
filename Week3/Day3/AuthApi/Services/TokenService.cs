using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public interface ITokenService
{
    Task<string> CreateTokenAsync(AppUser user);
}

public sealed class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;

    public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> CreateTokenAsync(AppUser user)
    {
        var key = _configuration["Jwt:Key"];
        if (string.IsNullOrWhiteSpace(key))
            throw new InvalidOperationException(
                "JWT signing key is not configured. Set Jwt:Key using user secrets or an environment variable.");

        var keyBytes = Encoding.UTF8.GetBytes(key);
        if (keyBytes.Length < 32)
            throw new InvalidOperationException("JWT signing key must be at least 32 bytes long.");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? user.Email ?? user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var signingKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT issuer is not configured."),
            audience: _configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT audience is not configured."),
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
