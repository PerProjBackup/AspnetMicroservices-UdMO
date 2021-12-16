using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
  public class CartModel : PageModel
  {
    private readonly IBasketService _basketService;

    public CartModel(IBasketService basketService)
    {
      _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
    }

    public BasketModel Cart { get; set; } = new BasketModel();

    public async Task<IActionResult> OnGetAsync()
    {  
      // Since we have not identified the user we should use a predefined username
      string userName = "swn";
      Cart = await _basketService.GetBasket(userName);

      return Page();
    }

    public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
    {
      // Since we have not identified the user we should use a predefined username
      string userName = "swn";
      BasketModel basket = await _basketService.GetBasket(userName);

      BasketItemModel item = basket.Items.Single(x => x.ProductId == productId);
      basket.Items.Remove(item);

      BasketModel basketUpdated = await _basketService.UpdateBasket(basket);

      return RedirectToPage();
    }
  }
}