using DemoAuth.Models.DTOs;

namespace DemoAuth.Core
{
    public interface IUserService
    {
        Task<bool> DeleteUser(string userId);
        Task<UserResponseDTO> GetUser(string userId);
        Task<bool> Update(string userId, UpdateUserRequest updateUser);
    }
}