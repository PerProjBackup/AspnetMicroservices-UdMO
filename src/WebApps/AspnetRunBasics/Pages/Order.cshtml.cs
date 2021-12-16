using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
  public class OrderModel : PageModel
  {
    private readonly IOrderService _orderService;

    public OrderModel(IOrderService orderService)
    {
      _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();

    public async Task<IActionResult> OnGetAsync()
    {    
      // Since we have not identified the user we should use a predefined username
      string userName = "swn";
      Orders = await _orderService.GetOrdersByUserName(userName);

      return Page();
    }
  }
}