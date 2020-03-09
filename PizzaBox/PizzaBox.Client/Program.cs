using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Client.Singletons;
using PizzaBox.Client.UserInterface;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  class Program
  {
    public static int[] pizzaSelect = new int[] {0, 0, 0};
    public static string[] pizzaType = new string[] {"Pep", "Cheese", "PinBac"};
    
    static void Main(string[] args)
    {
      //PostAllPizzas();
      //GetAllPizzas();
      //GetSizes();
      //GetUsernames();
      //GetLocations();
      // GetLocations();
      // Console.WriteLine(loc[1]);
      
      // var userType = Login();
      // if(userType == u)
      // {
        // **
      // }

      UI.CustomerUI();
      }        
    }

    // private static void GetAllPizzas()
    // {
    //   foreach (var p in _ps.Get())
    //   {
    //     Console.WriteLine(p.ToString());
    //   }
    // }

    // private static void PostAllPizzas()
    // {
    //   var pizzaType = _pt.Get(); // _db1
    //   var sizes = _sz.Get(); // _db2
    //   // order

    //   _ps.Update(pizzaType[0], sizes[0]);
    // }


}