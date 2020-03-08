using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  class Program
  {
    public static int[] pizzaSelect = new int[] {0, 0, 0};
    public static string[] pizzaType = new string[] {"Pep", "Cheese", "PinBac"};
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
    private static readonly PizzaTypeRepository _pt = new PizzaTypeRepository();
    private static readonly SizeRepository _sz = new SizeRepository();
    private static readonly OrderRepository _o = new OrderRepository();
    static void Main(string[] args)
    {
      PostAllPizzas();
      //GetSize();
      
      // var userType = Login();
      // if(userType == u)
      // {
        // **
      // }

    //   Console.WriteLine("Welcome to Papa's Pizzas");
      
    //   var ans = 0;      
    //   while(ans != 1 && ans != 2)
    //   {        
    //     Console.Write("Which Location do you want to order from?\n(1) Cooper or (2) Center St: ");
    //     int.TryParse(Console.ReadLine(), out ans );
    //   }
    //   // set store location based on answer

    //   var ans2 = 0;
    //   while(ans2 != 3)
    //   {
    //     Console.WriteLine("(1) Add Pizza");
    //     Console.WriteLine("(2) Remove Pizza");
    //     Console.WriteLine("(3) Submit Order");
    //     Console.Write("(Ctrl + C) Exit\n\t");
    //     int.TryParse(Console.ReadLine(), out ans2 );

    //     var ans3 = 0;
    //     if(ans2 == 1)
    //     {
    //       Console.WriteLine("Which Pizza would you like?");
    //       for(int i = 0; i < pizzaType.Length; i++)
    //       {
    //         Console.Write("({0}) {1} \t", i + 1, pizzaType[i]);
    //       }
    //       Console.WriteLine("\t");
    //       var ansArray = new List<int>() {1, 2, 3};
    //       int.TryParse(Console.ReadLine(), out ans3 );
    //       if(ansArray.Contains(ans3))
    //       {
    //         pizzaSelect[ans3 - 1] += 1;
    //       }
    //       else
    //         Console.WriteLine("Enter a valid Pizza Number");
    //     }
    //     else if(ans2 == 2)
    //     {
    //       // remove pizza
    //     }
    //     else if(ans2 == 3)
    //     {
    //       Console.WriteLine("\nPizza's Ordered:");
    //       for (int i = 0; i < pizzaSelect.Length; i++)
    //       {
    //         Console.WriteLine("{0} {1}", pizzaSelect[i], pizzaType[i]);
    //       }
    //     }
    //   }        
    }

    private static void GetSize()
    {
      foreach (var s in _sz.Get())
      {
        Console.WriteLine(s);
      }
    }

    private static void GetAllPizzas()
    {
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }

    private static void PostOrder()
    {
      //_o.Post();
    }

    private static void PostAllPizzas()
    {
      var pizzaType = _pt.Get(); // _db1
      var sizes = _sz.Get(); // _db2

      _ps.Post(pizzaType[0], sizes[0]);
    }
  }
}