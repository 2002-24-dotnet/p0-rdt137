using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Crust : APizzaComponent
  {
    public long CrustId { get; set; }

    public Crust()
    {
      CrustId = DateTime.Now.Ticks;
    }
  }
}