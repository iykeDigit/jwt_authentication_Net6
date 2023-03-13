using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuth.Models.DTOs.Mappings
{
    public class UserMappings
    {
        public static UserResponseDTO GetUserResponse(AppUser user) 
        {
            return new UserResponseDTO
            {
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static AppUser GetUser(RegistrationRequest request) 
        {
            return new AppUser
            {
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                PhoneNumber = request.PhoneNumber,
                UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName
            };
        }
    }
}
