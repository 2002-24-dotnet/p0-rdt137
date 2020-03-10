using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.UserInterface
{
  public class UsernameUI : RepositorySingleton, IUserInterface
  {
    public static List<string> usernames = new List<string>();
    public static List<User> userModel = new List<User>();
    
    public void Get()
    {
      foreach (var us in _us.Get())
      {
        usernames.Add(us.ToString());
      }
    }

    public void GetUsername()
    {
      foreach (var us in _us.Get())
      {
        userModel.Add(us);
      }
    }

    // public User AuthenticateUsername(string userId)
    // {
    //   try
    //   {
    //     return _us.Get(userId);
    //   }
    //   catch(NullReferenceException)
    //   {
    //     return null;
    //   }           
    // }
  }
}