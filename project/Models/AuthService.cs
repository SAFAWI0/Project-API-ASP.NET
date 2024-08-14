

using Microsoft.AspNetCore.Identity;
using project.DTOs;
using project.Interfaces;
using project.Models;

namespace project.Services
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserResponse> Registration(RegistrationDTO user)
        {
            var IdentityUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.UserName,
            };
            var result = await _userManager.CreateAsync(IdentityUser, user.Password);

            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Message = "User Created",
                    Success = true,
                };


            }
            return new UserResponse
            {
                Message = "User not Created",
                Success = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
    }
}
