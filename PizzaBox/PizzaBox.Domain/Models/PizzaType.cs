using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class PizzaType : APizzaComponent
  {
    public long TypeId { get; set; }
    public string Crust { get; set; }

    public List<Pizza> Pizzas { get; set; }
  }
}