using Restaurant.API.DTOs;
namespace Restaurant.API.Services.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);

}