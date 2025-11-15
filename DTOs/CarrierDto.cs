namespace LatestEcommAPI.DTOs;

public class CarrierDto
{
    public required int CarrierId { get; set; }
    public required string CarrierName { get; set; }
    public required bool IsActive { get; set; }
}