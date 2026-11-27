using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace ProductApi.Authentication;

public sealed class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IConfiguration _configuration;

    public ApiKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IConfiguration configuration)
        : base(options, logger, encoder)
    {
        _configuration = configuration;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var authorization) ||
            !System.Net.Http.Headers.AuthenticationHeaderValue.TryParse(authorization, out var header) ||
            !string.Equals(header.Scheme, "Bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(header.Parameter))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var suppliedKey = Encoding.UTF8.GetBytes(header.Parameter);
        foreach (var role in _configuration.GetSection("Authentication:ApiKeys").GetChildren())
        {
            var configuredKey = role.Value;
            if (string.IsNullOrEmpty(configuredKey))
                continue;

            var expectedKey = Encoding.UTF8.GetBytes(configuredKey);
            if (suppliedKey.Length == expectedKey.Length &&
                CryptographicOperations.FixedTimeEquals(suppliedKey, expectedKey))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, role.Key),
                    new Claim(ClaimTypes.Name, role.Key),
                    new Claim(ClaimTypes.Role, role.Key)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
        }

        return Task.FromResult(AuthenticateResult.Fail("Invalid bearer token."));
    }
}
