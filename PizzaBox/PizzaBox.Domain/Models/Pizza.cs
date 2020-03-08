using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public long PizzaId { get; set; }
    
    public decimal Cost
    {
      get
      {
        if (PizzaType == null || Size == null)
        {
          return 0;
        }

        return PizzaType.Cost + Size.Cost;
      }
    }

    #region Navigational Properties
    public PizzaType PizzaType { get; set; }
    public Order Order { get; set; }
    public Size Size { get; set; }

    #endregion

    public override string ToString()
    {
      return $"{PizzaId} {PizzaType} {Cost} {Size.Name ?? "N/A"} ";
    }
  }
}