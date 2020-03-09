using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.UserInterface
{
  public class OrderUI : RepositorySingleton, IUserInterface
  {
    public static List<string> orders = new List<string>();
    
    public void Get()
    {
      
    }
  }
}