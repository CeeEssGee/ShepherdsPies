using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Data;
public class ShepherdsPiesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    // add DbSets here
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Cheese> Cheeses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaTopping> PizzaToppings { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Topping> Toppings { get; set; }



    public ShepherdsPiesDbContext(DbContextOptions<ShepherdsPiesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
            new()
            {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
            },
            new()
            {
                Id = "f2498ab4-e4b6-4e61-92c0-9568e96a8145",
                Name = "Courtney",
                NormalizedName = "courtney"
            },
            new ()
            // {
            //     Id =
            // }
        }
        );

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new()
            {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

            new()
            {
            Id = "f2498ab4-e4b6-4e61-92c0-9568e96a8145",
            UserName = "Courtney",
            Email = "courtney@gmail.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

            new()
            {
            Id = "d9b5145a-739c-42d3-9e94-d2d439063d7e",
            UserName = "Jeremy",
            Email = "jeremy@gmail.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

            new()
            {
            Id = "a7bc4dd9-8f10-4e24-8c0c-ef09a24ec9a5",
            UserName = "Sean",
            Email = "sean@gmail.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

            new()
            {
            Id = "6a2f5d0b-3eac-4dab-ae9d-7f26d77e4a8c",
            UserName = "Rick",
            Email = "rick@gmail.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            }

        });

        // do I need to update this one when I add users?
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new()
            {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        },
        new()
        {
            Id = 2,
            IdentityUserId = "f2498ab4-e4b6-4e61-92c0-9568e96a8145",
            FirstName = "Courtney",
            LastName = "Gulledge",
            Address = "555 Ocean Avenue",
        },
        new()
        {
            Id = 3,
            IdentityUserId = "d9b5145a-739c-42d3-9e94-d2d439063d7e",
            FirstName = "Jeremy",
            LastName = "Gibeault",
            Address = "555 Ocean Avenue",
        },
        new()
        {
            Id = 4,
            IdentityUserId = "a7bc4dd9-8f10-4e24-8c0c-ef09a24ec9a5",
            FirstName = "Sean",
            LastName = "Gulledge",
            Address = "555 Ocean Avenue",
        },
        new()
        {
            Id = 5,
            IdentityUserId = "6a2f5d0b-3eac-4dab-ae9d-7f26d77e4a8c",
            FirstName = "Rick",
            LastName = "Gibeault",
            Address = "555 Ocean Avenue",
        }

        }
        );

        modelBuilder.Entity<Size>().HasData(new Size[]
        {
            new Size { Id = 1, Name = "Small", SizeCost = 10.00M },
            new Size { Id = 2, Name = "Medium", SizeCost = 12.00M },
            new Size { Id = 3, Name = "Large", SizeCost = 15.00M }
        });

        modelBuilder.Entity<Cheese>().HasData(new Cheese[]
        {
            new Cheese { Id = 1, Name = "Buffalo Mozzarella" },
            new Cheese { Id = 2, Name = "Four Cheese" },
            new Cheese { Id = 3, Name = "Vegan" },
            new Cheese { Id = 4, Name = "None (cheeseless)" }
        });

        modelBuilder.Entity<Sauce>().HasData(new Sauce[]
        {
            new Sauce { Id = 1, Name = "Marinara" },
            new Sauce { Id = 2, Name = "Arrabbiata" },
            new Sauce { Id = 3, Name = "Garlic White" },
            new Sauce { Id = 4, Name = "None (sauceless)" }
        });

        modelBuilder.Entity<Topping>().HasData(new Topping[]
        {
            new Topping { Id = 1, Name = "Sausage" },
            new Topping { Id = 2, Name = "Pepperoni" },
            new Topping { Id = 3, Name = "Mushroom" },
            new Topping { Id = 4, Name = "Onion" },
            new Topping { Id = 5, Name = "Green Pepper" },
            new Topping { Id = 6, Name = "Black Olive" },
            new Topping { Id = 7, Name = "Basil" },
            new Topping { Id = 8, Name = "Extra Cheese" }
        });

        modelBuilder.Entity<Pizza>().HasData(new Pizza[]
        {
            new Pizza {Id = 1, SizeId = 2, CheeseId = 1, SauceId = 1, OrderId = 1},
            new Pizza {Id = 2, SizeId = 1, CheeseId = 2, SauceId = 2, OrderId = 2},
            new Pizza {Id = 3, SizeId = 2, CheeseId = 3, SauceId = 3, OrderId = 2},
            new Pizza {Id = 4, SizeId = 3, CheeseId = 4, SauceId = 4, OrderId = 3},
            new Pizza {Id = 5, SizeId = 3, CheeseId = 2, SauceId = 2, OrderId = 4},
            new Pizza {Id = 6, SizeId = 1, CheeseId = 2, SauceId = 4, OrderId = 4},
            new Pizza {Id = 7, SizeId = 1, CheeseId = 1, SauceId = 3, OrderId = 5},
            new Pizza {Id = 8, SizeId = 1, CheeseId = 3, SauceId = 1, OrderId = 6},
            new Pizza {Id = 9, SizeId = 2, CheeseId = 4, SauceId = 4, OrderId = 6},
            new Pizza {Id = 10, SizeId = 3, CheeseId = 3, SauceId = 1, OrderId = 6},
            new Pizza {Id = 11, SizeId = 1, CheeseId = 2, SauceId = 1, OrderId = 7},
            new Pizza {Id = 12, SizeId = 2, CheeseId = 1, SauceId = 2, OrderId = 8},
            new Pizza {Id = 13, SizeId = 1, CheeseId = 1, SauceId = 3, OrderId = 8},
            new Pizza {Id = 14, SizeId = 2, CheeseId = 1, SauceId = 3, OrderId = 9},
            new Pizza {Id = 15, SizeId = 3, CheeseId = 2, SauceId = 1, OrderId = 9}
        });

        modelBuilder.Entity<PizzaTopping>().HasData(new PizzaTopping[]
        {
            new PizzaTopping {Id = 1, PizzaId = 1, ToppingId = 1, Quantity = 8},
            new PizzaTopping {Id = 2, PizzaId = 1, ToppingId = 8, Quantity = 8},
            new PizzaTopping {Id = 3, PizzaId = 1, ToppingId = 5, Quantity = 8},
            new PizzaTopping {Id = 4, PizzaId = 2, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 5, PizzaId = 3, ToppingId = 1, Quantity = 11},
            new PizzaTopping {Id = 6, PizzaId = 3, ToppingId = 2, Quantity = 7},
            new PizzaTopping {Id = 7, PizzaId = 4, ToppingId = 1, Quantity = 9},
            new PizzaTopping {Id = 8, PizzaId = 5, ToppingId = 3, Quantity = 12},
            new PizzaTopping {Id = 9, PizzaId = 5, ToppingId = 4, Quantity = 15},
            new PizzaTopping {Id = 10, PizzaId = 5, ToppingId = 5, Quantity = 7},
            new PizzaTopping {Id = 11, PizzaId = 6, ToppingId = 1, Quantity = 7},
            new PizzaTopping {Id = 12, PizzaId = 6, ToppingId = 7, Quantity = 4},
            new PizzaTopping {Id = 13, PizzaId = 7, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 14, PizzaId = 8, ToppingId = 2, Quantity = 11},
            new PizzaTopping {Id = 15, PizzaId = 9, ToppingId = 8, Quantity = 12},
            new PizzaTopping {Id = 16, PizzaId = 9, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 17, PizzaId = 10, ToppingId = 4, Quantity = 5},
            new PizzaTopping {Id = 18, PizzaId = 11, ToppingId = 1, Quantity = 6},
            new PizzaTopping {Id = 19, PizzaId = 11, ToppingId = 3, Quantity = 8},
            new PizzaTopping {Id = 20, PizzaId = 11, ToppingId = 6, Quantity = 7},
            new PizzaTopping {Id = 21, PizzaId = 12, ToppingId = 1, Quantity = 8},
            new PizzaTopping {Id = 22, PizzaId = 12, ToppingId = 5, Quantity = 9},
            new PizzaTopping {Id = 23, PizzaId = 13, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 24, PizzaId = 14, ToppingId = 2, Quantity = 10},
            new PizzaTopping {Id = 25, PizzaId = 15, ToppingId = 2, Quantity = 7},
            new PizzaTopping {Id = 26, PizzaId = 15, ToppingId = 3, Quantity = 8}
        });

        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer { Id = 1, Name = "John Doe", Address = "123 Main St", PhoneNumber = "555-123-4567", OrderId = 1 },
            new Customer { Id = 2, Name = "Jane Smith", Address = "456 Elm St", PhoneNumber = "555-987-6543", OrderId = 2 },
            new Customer { Id = 3, Name = "Bob Johnson", Address = "789 Oak Lane", PhoneNumber = "555-234-5678", OrderId = 3 },
            new Customer { Id = 4, Name = "Alice Brown", Address = "321 Birch Road", PhoneNumber = "555-876-5432", OrderId = 4 },
            new Customer { Id = 5, Name = "Tamara Goins", Address = "527 Main Street", PhoneNumber = "555-257-2858", OrderId = 5 },
            new Customer { Id = 6, Name = "Amy Jaekel", Address = "286 Ocean Avenue", PhoneNumber = "555-573-5468", OrderId = 6 },
            new Customer { Id = 7, Name = "Tamara Goins", Address = "25 1st Avenue", PhoneNumber = "555-825-8275", OrderId = 7 },
            new Customer { Id = 8, Name = "Joey Holland", Address = "98 Fake Street", PhoneNumber = "555-292-2260", OrderId = 8 },
            new Customer { Id = 9, Name = "Jeff Gribble", Address = "82 Baker Lane", PhoneNumber = "555-885-8820", OrderId = 9 },
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {Id = 1, EmployeeId = 2, DriverId = null, TableNumber = 3, TipAmount = 6.80M, DateTimePlaced = new DateTime(2023, 09, 26, 17, 0, 0)},
            new Order {Id = 2, EmployeeId = 2, DriverId = 3, TableNumber = null, TipAmount = 11M, DateTimePlaced = new DateTime(2023, 09, 16, 14, 25, 22)},
            new Order {Id = 3, EmployeeId = 3, DriverId = null, TableNumber = 4, DateTimePlaced = new DateTime(2023, 09, 27, 12, 04, 35)},
            new Order {Id = 4, EmployeeId = 4, DriverId = 3, TableNumber = null, TipAmount = 8.75M, DateTimePlaced = new DateTime(2023, 09, 28, 12, 04, 11)},
            new Order {Id = 5, EmployeeId = 3, DriverId = 3, TableNumber = null, TipAmount = 4.95M, DateTimePlaced = new DateTime(2023, 09, 28, 13, 48, 37)},
            new Order {Id = 6, EmployeeId = 4, DriverId = null, TableNumber = 1, TipAmount = 12M, DateTimePlaced = new DateTime(2023, 09, 28, 15, 22, 58)},
            new Order {Id = 7, EmployeeId = 2, DriverId = null, TableNumber = 2, DateTimePlaced = new DateTime(2023, 09, 29, 11, 07, 47)},
            new Order {Id = 8, EmployeeId = 3, DriverId = 3, TableNumber = null, TipAmount = 8.55M, DateTimePlaced = new DateTime(2023, 09, 29, 12, 34, 51)},
            new Order {Id = 9, EmployeeId = 2, DriverId = 3, TableNumber = null, TipAmount = 6.39M, DateTimePlaced = new DateTime(2023, 09, 29, 14, 41, 08)}
        }); 
    }
}