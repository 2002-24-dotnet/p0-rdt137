using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public string UserId { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    
    public List<Order> Orders { get; set; }
    
    public string ToString(int i)
    {
      if(i == 1)
        return $"{UserId ?? "N/A"}";
      else if(i == 2)
        return $"{Password ?? "N/A"}";
      else
        return String.Empty;
    }
  }
}