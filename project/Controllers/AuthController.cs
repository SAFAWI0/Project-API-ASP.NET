using Microsoft.AspNetCore.Mvc;
using project.DTOs;
using project.Interfaces;
using project.Models;

namespace project.Controllers
{
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/api/auth")]
        public async Task<UserResponse> Registration(RegistrationDTO user)
            
        {
            return await _authService.Registration(user);
        }
    }
}
