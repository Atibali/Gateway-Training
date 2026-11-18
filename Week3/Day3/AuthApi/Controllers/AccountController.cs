using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager,
                             SignInManager<AppUser> signInManager,
                             ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new AppUser { UserName = dto.Email, Email = dto.Email, FullName = dto.FullName };
        var result = await _userManager.CreateAsync(user, dto.Password); // hashes internally

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _userManager.AddToRoleAsync(user, "User");
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null) return Unauthorized("Invalid credentials");

        var check = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!check.Succeeded) return Unauthorized("Invalid credentials");

        return Ok(new { token = await _tokenService.CreateTokenAsync(user) });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-demo")]
    public IActionResult AdminDemo()
    {
        return Ok(new { message = "Admin role authorization succeeded." });
    }
}

public record RegisterDto(string Email, string Password, string FullName);
public record LoginDto(string Email, string Password);