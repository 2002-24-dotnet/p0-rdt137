using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Topping> Topping { get; set; }
    // public DbSet<Customer> Customer { get; set; }
    // public DbSet<Order> Order { get; set; }
    // public DbSet<Admin> Admin { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c => c.CrustId);
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<Size>().HasKey(s => s.SizeId);
      builder.Entity<Topping>().HasKey(t => t.ToppingId);

      builder.Entity<Crust>().HasMany<Pizza>().WithOne(p => p.Crust);
      builder.Entity<Size>().HasMany<Pizza>().WithOne(p => p.Size);
      builder.Entity<Topping>().HasMany<Pizza>();

      // builder.Entity<Crust>().HasMany<Crust>();
      // builder.Entity<Pizza>().HasOne<Size>();
      // builder.Entity<Pizza>().HasMany<Topping>();

      // builder.Entity<Crust>().HasMany<Pizza>();
      // builder.Entity<Size>().HasMany<Pizza>();
      // builder.Entity<Topping>().HasMany<Pizza>();

      builder.Entity<Pizza>().HasData(new Pizza());
      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { Name = "Thin Crust", Price = 2.00M },
        new Crust() { Name = "New York Style", Price = 3.00M },
        new Crust() { Name = "Deep Dish", Price = 4.00M }

      });
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { Name = "Small", Price = 7.00M },
        new Size() { Name = "Medium", Price = 10.00M },
        new Size() { Name = "Large", Price = 12.00M }
      });
      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { Name = "Cheese", Price = 0.25M },
        new Topping() { Name = "Sauce", Price = 0.50M },
        new Topping() { Name = "Pepperonni", Price = 0.75M },
        new Topping() { Name = "Bacon", Price = 1.00M },
        new Topping() { Name = "Pinneapple", Price = 1.00M }        
      });
    }
  }
}