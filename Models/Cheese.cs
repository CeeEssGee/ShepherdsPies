using System.ComponentModel.DataAnnotations;
using ShepherdsPies.Models;

public class Cheese
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}