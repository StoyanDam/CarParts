using Microsoft.AspNetCore.Identity;

namespace CarPartsBg.Data.Models;
public class User:IdentityUser<int>

{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Adress { get; set; }

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
