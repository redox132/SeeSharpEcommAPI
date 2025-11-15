namespace LatestEcommAPI.DTOs;

public class CountryDto
{
    public required int CountryId { get; set; }
    public required string CountryCode { get; set; }
    public required string CountryName { get; set; }
    public required bool IsActive { get; set; }
}