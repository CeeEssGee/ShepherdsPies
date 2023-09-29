using System.ComponentModel.DataAnnotations;
using ShepherdsPies.Models;

public class Sauce
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}