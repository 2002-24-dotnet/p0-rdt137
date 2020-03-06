using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzeriaSingleton
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();
    public static PizzeriaSingleton Instance { get { return _ps; } }
    private PizzeriaSingleton() {}

    public List<Pizza> Get(string user, string store)
    {
      return _pr.Get().Where(p => p.Name == user).ToList();
    }

    public List<Pizza> Get()
    {
      return _pr.Get();
    }

    public bool Post(Crust crust, Size size, List<Topping> toppings)
    {
      var p = new Pizza()
      {
        Crust = crust,
        Size = size,
        Toppings = toppings
      };

      return _pr.Post(p);
    }
  }
}