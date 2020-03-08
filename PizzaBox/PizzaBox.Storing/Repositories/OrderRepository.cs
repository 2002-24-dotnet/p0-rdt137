using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<Order> Get()
    {
      return _db.Order.Include(o => o.OrderId).Include(o => o.User).Include(o => o.Location).ToList();
    }

    public Order Get(long id)
    {
      return _db.Order.SingleOrDefault(o => o.OrderId == id);
    }

    public bool Post(Order order)
    {
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Order order)
    {
      Order o = Get(order.OrderId);

      o = order;
      return _db.SaveChanges() == 1;
    }
  }
}