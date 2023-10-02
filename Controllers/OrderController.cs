using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Data;
using ShepherdsPies.Models;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public OrderController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.Driver)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Size)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Cheese)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Sauce)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.PizzaToppings)
            .ThenInclude(pt => pt.Topping)
            .OrderByDescending(o => o.DateTimePlaced)
            .ToList()
        );
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteOrder(int id)
    {
        Order orderToDelete = _dbContext.Orders.SingleOrDefault(o => o.Id == id);

        if (orderToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Orders.Remove(orderToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
}