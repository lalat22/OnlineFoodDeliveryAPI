using FoodCourt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourt.Services
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(UserDTO model);
        Task<UserDTO> AuthenticateAsync(string email, string password);
        string GenerateToken(UserDTO user);
    }
}
