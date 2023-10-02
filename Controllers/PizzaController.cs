using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Data;
using ShepherdsPies.Models;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;
    public PizzaController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Pizzas
        .Include(p => p.Size)
        .Include(p => p.Sauce)
        .Include(p => p.Cheese)
        .Include(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .ToList()
        );
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPizzaById(int id)
    {
        Pizza pizza = _dbContext.Pizzas
        .Include(p => p.Size)
        .Include(p => p.Sauce)
        .Include(p => p.Cheese)
        .Include(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .SingleOrDefault(p => p.Id == id);

        if (pizza == null)
        {
            return NotFound();
        }

        return Ok(pizza);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeletePizza(int id)
    {
        Pizza pizzaToDelete = _dbContext.Pizzas.SingleOrDefault(o => o.Id == id);

        if (pizzaToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Pizzas.Remove(pizzaToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
}