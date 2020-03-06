using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : APizzaComponent
  {
    public long SizeId { get; set; }

    public Size()
    {
      SizeId = DateTime.Now.Ticks;
    }
  }
}