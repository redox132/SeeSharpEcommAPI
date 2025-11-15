using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc;
using LatestEcommAPI.DTOs;


namespace LatestEcommAPI.Controllers;

[ApiController]
[Route("api/carriers")]
public class CarrierController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSupportedCarriers()
    {
        using (var connection = new SqliteConnection("Data source=Data/db.db"))
        {
            await connection.OpenAsync();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM carriers";

            var carriers = new List<object>();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    carriers.Add(
                        new CarrierDto
                        {
                            CarrierId = reader.GetInt32(0),
                            CarrierName = reader.GetString(1),
                            IsActive = Convert.ToBoolean(reader.GetBoolean(2))
                        }
                    );
                }
            }
            return Ok(new { message = "OK", carriers });
        }
    }
}