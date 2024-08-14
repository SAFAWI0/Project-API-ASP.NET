using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.DTOs;
using project.Interfaces;
using project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserResponse> Registration(RegistrationDTO user)
        {
            var identityUser = new User
            {
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);

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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync(); // Fetch all users
        }






        
















    }
}
