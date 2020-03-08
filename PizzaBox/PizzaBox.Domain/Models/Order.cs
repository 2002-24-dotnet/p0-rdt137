using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long OrderId { get; set; }    
    public Store Location { get; set; }    
    public User User { get; set; }
    public List<Pizza> Pizzas { get; set; }    

    
    public Order()
    {
      OrderId = DateTime.Now.Ticks;
    }
  }
}