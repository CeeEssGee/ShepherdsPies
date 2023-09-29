using System.ComponentModel.DataAnnotations;
using ShepherdsPies.Models;

public class Size
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal SizeCost { get; set; }
}