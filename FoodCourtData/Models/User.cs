using System;
using System.Collections.Generic;

namespace FoodCourtData.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int RoleId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? ProfilePicture { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public int StatusId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual AccountStatus Status { get; set; } = null!;
}
