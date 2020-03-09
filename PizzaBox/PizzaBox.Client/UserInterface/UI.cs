using System;
using System.Collections;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.UserInterface
{
  public class UI : RepositorySingleton
  {

    public static void CustomerUI()
    {
      StoreUI sUI = new StoreUI();
      sUI.Get();
      PizzaTypeUI ptUI = new PizzaTypeUI();      
      ptUI.Get();
      SizeUI szUI = new SizeUI();
      szUI.Get();
      
      Console.WriteLine("Welcome to Papa's Pizzas");
      
      var loc = StoreUI.locations;
      var userLoc = 0;
      while(userLoc != 1 && userLoc != 2)
      {        
        Console.Write("Which Location do you want to order from?\n (1) {0}\t\t(2) {1}\n\n", loc[0], loc[1]);
        int.TryParse(Console.ReadLine(), out userLoc );
      }
      // set store location based on answer
      var typeId = new SortedList();
      var sizeId = new SortedList();
      var pizzaSelect = new int[] {0, 0, 0};

      var x = 0;
      var ans2 = 0;      
      while(ans2 != 3)
      {
        Console.WriteLine("\n(1) Add Pizza");
        Console.WriteLine("(2) Remove Pizza");
        Console.WriteLine("(3) Checkout");
        Console.WriteLine("(Ctrl + C) Exit\n");
        int.TryParse(Console.ReadLine(), out ans2 );
        
        var pztype = PizzaTypeUI.pizzatypes;
        var size = SizeUI.sizes;

        // add pizza
        if(ans2 == 1)
        {
          Console.WriteLine("\nWhich pizza would you like?");
          for(int i = 0; i < pztype.Count; i++)
          {
            Console.Write("({0}) {1} \t", i + 1, pztype[i]);
          }
          Console.WriteLine("\n");

          var ans3 = 0;
          var ansArray = new List<int>() {1, 2, 3};
          int.TryParse(Console.ReadLine(), out ans3 );
          if(ansArray.Contains(ans3))
          {
            Console.WriteLine("\nWhat size would you like?");
            for(int i = 0; i < size.Count; i++)
            {
              Console.Write("({0}) {1} \t", i + 1, size[i]);
            }
            Console.WriteLine("\n");

            var ans4 = 0;
            
            var ansArray2 = new List<int>() {1, 2, 3};
            int.TryParse(Console.ReadLine(), out ans4 );
            if(ansArray2.Contains(ans4))
            {
              typeId.Add(x, ans3);
              sizeId.Add(x, ans4);  
              x++;         
            }
            else
              Console.WriteLine("Enter a valid size");                       
          }
          else
            Console.WriteLine("Enter a valid pizza");
        }

        // remove pizza
        else if(ans2 == 2)
        {
          Console.WriteLine("\nWhich pizza would you like to remove?");

          Console.WriteLine("\nChoose number to remove:");
          for (int i = 0; i < typeId.Count; i++)
          {
            Console.WriteLine("({2}) {0} {1}", size[(int) sizeId.GetByIndex(i) - 1], pztype[(int) sizeId.GetByIndex(i) - 1], i + 1);
          }
          Console.WriteLine("\n");

          var removeAns = 0;
          int.TryParse(Console.ReadLine(), out removeAns );
          if(removeAns >= 0 && removeAns <= typeId.Count)
          {
            typeId.RemoveAt(removeAns - 1);
            sizeId.RemoveAt(removeAns - 1);
          }
          else
            Console.WriteLine("Enter a valid pizza number");
        }

        // checkout
        else if(ans2 == 3)
        {
          Console.WriteLine("\nFinal Order List:");
          for (int i = 0; i < typeId.Count; i++)
          {
            Console.WriteLine("{2} {0} {1}", size[(int) sizeId.GetByIndex(i) - 1], pztype[(int) sizeId.GetByIndex(i) - 1], i + 1);
          }        
                    
          sUI.GetLocation();
          var locModel = StoreUI.locModel;
          szUI.GetModel();
          var sizeModel = SizeUI.sizeModel;
          ptUI.GetPizzaType();
          var ptModel = PizzaTypeUI.ptModel;

          // var sizeList = _sz.Get();
          // List<string> sizeLCost = new List<string>();
          // foreach (var price in sizeList)
          // {
          //   sizeLCost.Add(price.GetCost());
          // }

          // var ptList = _pt.Get();
          // var list = ptList[0];
          // List<string> ptLCost = new List<string>();
          // foreach (var price in ptList)
          // {
          //   ptLCost.Add(price.GetCost());
          // }

          var pt = _pt.Get();
          var s = _sz.Get();
          

          var o = new Order();
          var st = new Store();
          o.Location = locModel[userLoc - 1];            
          
          _o.Update(o);

          for(int i = 0; i < typeId.Count; i++)
          {
            var p = new Pizza();

            //p.Size = sizeModel[(int) sizeId[i] - 1];
            //p.PizzaType = ptModel[(int) typeId[i] - 1];

            // decimal ptCost = 0;
            // decimal sCost = 0;

            // Decimal.TryParse(ptLCost[typeId[i] - 1], out ptCost);
            // Decimal.TryParse(sizeLCost[sizeId[i] - 1], out sCost);

            var pizzaType = pt[(int) sizeId.GetByIndex(i) - 1];
            var siz = s[(int) sizeId.GetByIndex(i) - 1];

            pizzaType.Pizzas = new List<Pizza> { p }; // p.crust = *crustId
            siz.Pizzas = new List<Pizza> { p };

            p.Cost = pizzaType.Cost + siz.Cost;
            //p.Cost = ptCost + sCost;

            p.Order = o;

            var worked = _pr.Update(p);
          }

          break;
        }

        // handling exception
        else
          continue;
  
        // display what customers currently ordered
        Console.WriteLine("\nCurrent Order List:");
        for (int i = 0; i < typeId.Count; i++)
        {
          Console.WriteLine("{2} {0} {1}", size[(int) sizeId.GetByIndex(i) - 1], pztype[(int) sizeId.GetByIndex(i) - 1], i + 1);
        }      
      }      
    }
    public static void AdminUI()
    {
      var loc = StoreUI.locations;
      var adminAns = "";
      while(!loc.Contains(adminAns))
      {        
        Console.Write("Choose a location:\n {0}\t\t{1}\n\n", loc[0], loc[1]);
        adminAns = Console.ReadLine();
      }

      Console.WriteLine("(1) Order History\t(2) Store Sales");
      // pull from data base : select
      var adminAns2 = 0;
      int.TryParse(Console.ReadLine(), out adminAns2 );
      
      if(adminAns2 == 1)
      {
        // select User.UserId, Order.OrderId, Count(PizzaId) as OrderNumber
        // multiple selects??
      }
      else if(adminAns2 == 2)
      {
        // select PizzaType.Name, Count(Order.OrderId), Sum(Pizza.Cost)
        // multiple selects??
      }
    }  
  }
}