using Shopping.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
  public interface IBasketService
  {
    Task<BasketModel> GetBasket(string userName);
  }
}
