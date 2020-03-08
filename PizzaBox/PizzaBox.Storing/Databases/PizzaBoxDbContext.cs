using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<PizzaType> PizzaType { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }  
    public DbSet<Store> Store { get; set; }  
    public DbSet<Size> Size { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<PizzaType>().HasKey(pt => pt.TypeId);
      builder.Entity<Order>().HasKey(o => o.OrderId);
      builder.Entity<User>().HasKey(u => u.UserId);
      builder.Entity<Store>().HasKey(s => s.Location);
      builder.Entity<Size>().HasKey(s => s.SizeId);

      builder.Entity<PizzaType>().HasMany(pt => pt.Pizzas).WithOne(p => p.PizzaType);
      builder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.Order);
      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
      builder.Entity<Store>().HasMany(s => s.Orders).WithOne(o => o.Location);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);

      builder.Entity<PizzaType>().HasData(new PizzaType[]
      {
        new PizzaType() { TypeId = 1, Name = "PepPizza", Crust = "Crust1", Cost = 8.00M },
        new PizzaType() { TypeId = 2, Name = "CheesePizza", Crust = "Crust121", Cost = 7.00M },
        new PizzaType() { TypeId = 3, Name = "PinBacPizza", Crust = "Crust432", Cost = 10.00M },
      });

      builder.Entity<User>().HasData(new User[]
      {
        new User() { UserId = "user1", Password = "123", UserType = "Customer"},
        new User() { UserId = "user2", Password = "234", UserType = "Admin"}
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { Location = "Cooper"},
        new Store() { Location = "S West St"}
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { SizeId = 1, Name = "Large", Cost = 12.00M },
        new Size() { SizeId = 2, Name = "Medium", Cost = 10.00M },
        new Size() { SizeId = 3, Name = "Small", Cost = 8.00M },
      });
      
      
      // builder.Entity<Crust>().HasKey(c => c.CrustId);
      // builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      // builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });
      // builder.Entity<Size>().HasKey(s => s.SizeId);
      // builder.Entity<Topping>().HasKey(t => t.ToppingId);

      // builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      // builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);
      // builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      // builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingId);


      // builder.Entity<Crust>().HasData(new Crust[]
      // {
      //   new Crust() { Name = "Deep Dish", Price = 3.50M },
      //   new Crust() { Name = "New York Style", Price = 2.50M },
      //   new Crust() { Name = "Thin Crust", Price = 1.50M }
      // });

      // builder.Entity<Size>().HasData(new Size[]
      // {
      //   new Size() { Name = "Large", Price = 12.00M },
      //   new Size() { Name = "Medium", Price = 10.00M },
      //   new Size() { Name = "Small", Price = 8.00M },
      // });

      // builder.Entity<Topping>().HasData(new Topping[]
      // {
      //   new Topping() { Name = "Cheese", Price = 0.25M },
      //   new Topping() { Name = "Pepperoni", Price = 0.50M },
      //   new Topping() { Name = "Tomato Sauce", Price = 0.75M },
      // });
    }
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    public PizzaBoxDbContext Instance { get { return _db; } }
  }
}
