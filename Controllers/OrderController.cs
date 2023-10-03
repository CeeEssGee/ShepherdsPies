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

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetOrderById(int id)
    {
        Order order = _dbContext.Orders
        .Include(o => o.Employee)
        .Include(o => o.Driver)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Size)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Sauce)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Cheese)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .SingleOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
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

    [HttpPost]
    // [Authorize]
    public IActionResult CreateOrder(Order order)
    {


        foreach (var p in order.Pizzas)
        {
            p.Size = _dbContext.Sizes.SingleOrDefault(s => s.Id == p.SizeId);
            p.Sauce = _dbContext.Sauces.SingleOrDefault(s => s.Id == p.SauceId);
            p.Cheese = _dbContext.Cheeses.SingleOrDefault(c => c.Id == p.CheeseId);
            foreach (var t in p.PizzaToppings)
            {
                t.Topping = _dbContext.Toppings.SingleOrDefault(top => top.Id == t.ToppingId);
            }
        }

        order.DateTimePlaced = DateTime.Now;

        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return Created($"/api/order/{order.Id}", order);


    }


    [HttpPut("{id}")]
    [Authorize]
    public IActionResult EditOrder(int id, Order updatedOrder)
    {
        Order order = _dbContext.Orders.SingleOrDefault(o => o.Id == id);

        if (order != null)
        {
            updatedOrder.Employee = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == updatedOrder.EmployeeId);
            updatedOrder.Driver = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == updatedOrder.DriverId);

            foreach (var p in updatedOrder.Pizzas)
            {
                p.Size = _dbContext.Sizes.SingleOrDefault(s => s.Id == p.SizeId);
                p.Cheese = _dbContext.Cheeses.SingleOrDefault(c => c.Id == p.CheeseId);
                p.Sauce = _dbContext.Sauces.SingleOrDefault(s => s.Id == p.SauceId);
                foreach (var t in p.PizzaToppings)
                {
                    t.Topping = _dbContext.Toppings.SingleOrDefault(top => top.Id == t.ToppingId);
                }
            }

            order.EmployeeId = updatedOrder.EmployeeId;
            order.Employee = updatedOrder.Employee;
            order.TableNumber = updatedOrder.TableNumber;
            order.DriverId = updatedOrder.DriverId;
            order.Driver = updatedOrder.Driver;
            order.TipAmount = updatedOrder.TipAmount;
            order.Pizzas = updatedOrder.Pizzas;

            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();
    }
}