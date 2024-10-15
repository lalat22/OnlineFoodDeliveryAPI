using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourt.DTO
{
    public class UserDTO
    {
        public int UserId{  get; set; }
        public required string FirstName { get; set; } 
        public required string LastName { get; set; }  
        public required string Email { get; set; }    
        public required string Password { get; set; }  
        public required string Phone { get; set; }   
        public required string AddressLine1 { get; set; } 
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }       
        public required string State { get; set; }  
        public required string PostalCode { get; set; }
        public required string Country { get; set; } 
        public DateOnly? DateOfBirth { get; set; } 
        public string? ProfilePicture { get; set; } 
        public int RoleId { get; set; }          
        public int StatusId { get; set; } 
    }
}
