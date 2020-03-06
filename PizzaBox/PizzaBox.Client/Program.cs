using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
  class Program
  {
    public static int[] pizzaSelect = new int[] {0, 0, 0};
    public static string[] pizzaType = new string[] {"Pep", "Cheese", "PinBac"};
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
    static void Main(string[] args)
    {
      // var userType = Login();
      // if(userType == u)
      // {
        // **
      // }

      Console.WriteLine("Welcome to Papa's Pizzas");
      
      var ans = 0;      
      while(ans != 1 && ans != 2)
      {        
        Console.Write("Which Location do you want to order from?\n(1) Cooper or (2) Center St: ");
        int.TryParse(Console.ReadLine(), out ans );
      }
      // set store location based on answer

      var ans2 = 0;
      while(ans2 != 3)
      {
        Console.WriteLine("(1) Add Pizza");
        Console.WriteLine("(2) Remove Pizza");
        Console.WriteLine("(3) Submit Order");
        Console.Write("(Ctrl + C) Exit\n\t");
        int.TryParse(Console.ReadLine(), out ans2 );

        var ans3 = 0;
        if(ans2 == 1)
        {
          Console.WriteLine("Which Pizza would you like?");
          for(int i = 0; i < pizzaType.Length; i++)
          {
            Console.Write("({0}) {1} \t", i + 1, pizzaType[i]);
          }
          Console.WriteLine("\t");
          var ansArray = new List<int>() {1, 2, 3};
          int.TryParse(Console.ReadLine(), out ans3 );
          if(ansArray.Contains(ans3))
          {
            pizzaSelect[ans3 - 1] += 1;
          }
          else
            Console.WriteLine("Enter a valid Pizza Number");
        }
        else if(ans2 == 2)
        {
          // remove pizza
        }
        else if(ans2 == 3)
        {
          Console.WriteLine("\nPizza's Ordered:");
          for (int i = 0; i < pizzaSelect.Length; i++)
          {
            Console.WriteLine("{0} {1}", pizzaSelect[i], pizzaType[i]);
          }
        }
      }
      
      
      // GetAllPizzas();
    }

    private static void GetAllPizzas()
    {     
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }

    private static void PostAllPizzas()
    {
      //var cs = _
    }
  }
}