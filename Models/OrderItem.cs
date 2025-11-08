namespace LatestEcommAPI.Models;

public class OrderItem
{
    public required int Id { get; set; }
    public required int Orderid { get; set; }
    public required int Quantity { get; set; }

    // Optional: navigation property
    public Order? Order { get; set; }
    public int OrderId { get; set; }
}