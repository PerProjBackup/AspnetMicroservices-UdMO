﻿using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
  public interface IBasketService
  {
    Task<BasketModel> GetBasket(string userName);
    Task<BasketModel> UodateBasket(BasketModel model);
    Task CheckoutBasket(BasketCheckoutModel model);
  }
}
