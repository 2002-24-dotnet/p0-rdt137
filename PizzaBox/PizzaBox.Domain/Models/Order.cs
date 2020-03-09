using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long OrderId { get; set; }    
    public Store Location { get; set; }    
    public User User { get; set; }
    //public Pizza Pizza { get; set; }
    public List<Pizza> Pizzas { get; set; }    

    
    public Order()
    {
    }
  }
}