namespace Restaurant.API.Models;

public class Order
{
    public int Id { get; set; }
    public int userId { get; set; }
    public User user { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public ICollection<OrderItem> OrderItems{ get; set; }
}