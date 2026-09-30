using Restaurant.API.Services.Interfaces;
using Restaurant.API.Data;
using Restaurant.API.DTOs;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Models;

namespace Restaurant.API.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly JwtHelper _jwtHelper;
    public AuthService(ApplicationDbContext context,JwtHelper jwtHelper)
    {
        _context = context;
        _jwtHelper=jwtHelper;
    }
    public async Task RegisterAsync(RegisterDto dto)
    {
        bool userExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (userExists)
        {
            throw new Exception("User Already exists");
        }
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "Customer"
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null)
        {
            throw new Exception("Invalid Email or Password");
        }
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!isPasswordValid)
        {
            throw new Exception("Invalid Email or Password");
        }
       string token = _jwtHelper.GenerateToken(user);
       //string token="abcerf";
        return token;
    }


}
