using DemoAuth.Models.DTOs;

namespace DemoAuth.Core
{
    public interface IAuthentication
    {
        Task<UserResponseDTO> Login(UserRequest userRequest);
        Task<UserResponseDTO> Register(RegistrationRequest registrationRequest);
    }
}