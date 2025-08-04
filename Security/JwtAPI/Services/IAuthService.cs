using JwtAPI.Entities;
using JwtAPI.Models;

namespace JwtAPI.Services
{
    public interface IAuthService
    {
        Task<User?> Register(UserDto request);
        Task<string?> Login(UserDto request);
    }
}