using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Client.UserInterface
{
  public class PizzaUI : RepositorySingleton, IUserInterface
  {
    public static List<string> pizzas = new List<string>();
    
    public void Get()
    {

    }
  }
}