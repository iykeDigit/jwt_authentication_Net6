using DemoAuth.Models;

namespace DemoAuth.Core
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}