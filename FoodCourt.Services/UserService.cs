using FoodCourt.Common;
using FoodCourt.DTO;
using FoodCourtData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodCourt.Services
{
    public class UserService : IUserService
    {
        private readonly LalatdigitallibraryFoodCourtDbContext _context;
        private readonly IConfiguration _config;

        public UserService(LalatdigitallibraryFoodCourtDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<UserDTO> RegisterAsync(UserDTO model)
        {
            // Check if user already exists
            if (_context.Users.Any(u => u.Email == model.Email))
                throw new Exception("User already exists.");

            // Create a new User 
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = HashPassword(model.Password), 
                Phone = model.Phone,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Country = model.Country,
                DateOfBirth =model.DateOfBirth,
                ProfilePicture = model.ProfilePicture,
                RoleId = (int)UserRoleEnum.Customer,    
                StatusId = model.StatusId, 
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Add the new user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // Save changes to the database

            // Optionally return a UserDTO after registration
            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode,
                Country = user.Country,
                RoleId = user.RoleId,
                StatusId = user.StatusId,
                ProfilePicture = user.ProfilePicture,
                Password = user.Password,
                UserId = user.UserId,
            };
        }
        public async Task<UserDTO> AuthenticateAsync(string email, string password)
        {
            var hashedPassword = HashPassword(password); // Replace with secure hashing method
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

            if (user == null)
                return null;

            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode,
                Country = user.Country,
                RoleId = user.RoleId,
                StatusId = user.StatusId,
                ProfilePicture = user.ProfilePicture,
                Password = user.Password,
                UserId = user.UserId,
            };
        }
        public string GenerateToken(UserDTO user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // HashPassword method (for demo purposes, replace with secure hashing logic)
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
