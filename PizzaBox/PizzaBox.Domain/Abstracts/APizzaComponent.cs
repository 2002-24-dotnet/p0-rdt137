using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public class APizzaComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    #region Navigational Properties
    //public virtual long PizzaId { get; set; }
    public virtual Pizza Pizza { get; set; }

    #endregion
  }
}