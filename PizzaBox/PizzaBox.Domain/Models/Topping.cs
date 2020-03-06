using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : APizzaComponent
  {
    public long ToppingId { get; set; }

    public Topping()
    {
      ToppingId = DateTime.Now.Ticks;
    }
  }
}