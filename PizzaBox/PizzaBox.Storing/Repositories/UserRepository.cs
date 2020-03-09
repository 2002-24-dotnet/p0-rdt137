using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<User> Get()
    {
      return _db.User.ToList();
    }

    public User Get(string id)
    {
      return _db.User.SingleOrDefault(u => u.UserId == id);
    }

    public bool Post(User user)
    {
      _db.User.Add(user);
      return _db.SaveChanges() == 1;
    }

    public bool Put(User user)
    {
      User u = Get(user.UserId);

      u = user;
      return _db.SaveChanges() == 1;
    }
  }
}