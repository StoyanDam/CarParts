namespace CarPartsBg.Data.Models;
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public decimal Price { get; set; }

    public int Availability { get; set; }

    public string Type { get; set; }

    public string CarMark { get; set; }

    public string CarModel { get; set; }

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

}
