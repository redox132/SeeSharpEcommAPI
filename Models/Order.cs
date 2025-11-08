namespace LatestEcommAPI.Models;

public class Order
{
    public int UserId { get; set; }
    public List<OrderItem> Orders { get; set; } = new();
}