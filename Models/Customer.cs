using System.ComponentModel.DataAnnotations;
using ShepherdsPies.Models;

public class Customer
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int OrderId { get; set; }
    public List<Order> Orders { get; set; }
}