using LatestEcommAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet("{id}/items")]
    public IActionResult GetOrderItems([FromRoute] int id)
    {
        using (var connection = new SqliteConnection("Data source=Data/db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
            SELECT o.id, o.order_date, oi.product_id, oi.quantity
            FROM orders o
            JOIN order_item oi ON o.id = oi.order_id
            WHERE o.user_id = $id;
        ";
            command.Parameters.AddWithValue("$id", id);
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return Ok(new { message = $"No orders found for user with ID {id}" });
            }

            var orders = new List<object>();
            while (reader.Read())
            {
                orders.Add(new
                {
                    orderId = reader.GetInt32(0),
                    orderDate = reader.GetDateTime(1),
                    productId = reader.GetInt32(2),
                    quantity = reader.GetInt32(3)
                });
            }

            return Ok(new { message = "OK", orders });
        }
    }
}