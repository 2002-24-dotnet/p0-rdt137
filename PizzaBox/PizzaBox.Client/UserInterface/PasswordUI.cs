using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

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

    // public User AuthenticatePassword(string userId, string password)
    // {
    //   try
    //   {
    //     return _us.Check(userId, password);
    //   }
    //   catch(NullReferenceException)
    //   {
    //     return null;
    //   }     
    // }
  }
}