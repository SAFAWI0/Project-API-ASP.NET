using project.DTOs;
using project.Models;

namespace project.Interfaces
{
    public interface IAuthService
    {
        public Task<UserResponse> Registration(RegistrationDTO user);
        public Task<IEnumerable<User>> GetAllUsers();
     
       
    }
}
