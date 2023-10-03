using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShepherdsPies.Models;


public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public UserProfile? Employee { get; set; }
    public int? TableNumber { get; set; }
    public int? DriverId { get; set; }
    [ForeignKey("DriverId")]
    public UserProfile? Driver { get; set; }
    private static decimal _deliveryCost = 5.00M;
    public decimal? TipAmount { get; set; }
    [Required]
    public DateTime DateTimePlaced { get; set; }
    public List<Pizza>? Pizzas { get; set; }
    // calculated Total Cost
    public decimal TotalCost
    {
        get
        {
            decimal total = 0.0M;

            foreach (Pizza pizza in Pizzas)
            {
                total += pizza.Cost;
            }
            if (DriverId != null)
            {
                total += _deliveryCost;
            }

            if (TipAmount != null)
            {
                total += (decimal)TipAmount;
            }

            return total;
        }
    }
}