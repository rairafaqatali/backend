using RealStateSearchPortal.Application.DTOs;

namespace RealStateSearchPortal.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
