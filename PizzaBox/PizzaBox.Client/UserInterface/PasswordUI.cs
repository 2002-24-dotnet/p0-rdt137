using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Client.UserInterface
{
  public class PasswordUI : RepositorySingleton, IUserInterface
  {
    public static List<string> passwords = new List<string>();
    
    public void Get()
    {
      foreach (var pw in _us.Get())
      {
        passwords.Add(pw.ToString());
      }
    }

    public void Update()
    {
      // next time :)
    }
  }
}