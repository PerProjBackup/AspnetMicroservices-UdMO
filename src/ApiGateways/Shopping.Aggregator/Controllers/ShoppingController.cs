using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ShoppingController : ControllerBase
  {
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;

    public ShoppingController(ICatalogService catalogService, IBasketService basketService,
          IOrderService orderService)    {
      _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
      _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
      _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    [HttpGet("{userName}", Name = "GetShopping")]
    [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
    {
      // get bakset with username
      // iterate basket items and consume products with basket item productID member
      // map product related members into basketitem dto with extended columns
      // consume ordering microservices in order to retrieve order list
      // return root ShoppingModel dto class which includes all responses

      BasketModel basket = await _basketService.GetBasket(userName);

      foreach (BasketItemExtendedModel item in basket.Items)
      {
        CatalogModel product = await _catalogService.GetCatalog(item.ProductId);

        // set additional product fields onto basket item
        item.ProductName = product.Name;
        item.Category = product.Category;
        item.Summary = product.Summary;
        item.Description = product.Description;
        item.ImageFile = product.ImageFile;
      }

      IEnumerable<OrderResponseModel> orders = await _orderService.GetOrdersByUserName(userName);

      var shoppingModel = new ShoppingModel
      {
        UserName = userName,
        BasketWithProducts = basket,
        Orders = orders
      };

      return Ok(shoppingModel);
    }

  }
}
