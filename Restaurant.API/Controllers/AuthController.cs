using Microsoft.AspNetCore.Mvc;
using Restaurant.API.DTOs;
using Restaurant.API.Services.Interfaces;
using Restaurant.API.Services;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService=authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult>Register(RegisterDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok();
    }
    
    [HttpPost("login")]
   public async Task<IActionResult> Login(LoginDto dto)
    {
        var token=await _authService.LoginAsync(dto);
        return Ok(token);

    }

}