using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using ShepherdsPies.Models;

public class Topping
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal Price { get; } = 0.50M;
}