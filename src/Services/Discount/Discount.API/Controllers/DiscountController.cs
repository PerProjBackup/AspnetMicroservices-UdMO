using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class DiscountController : ControllerBase
  {
    private readonly ILogger<DiscountController> _logger;

    public DiscountController(ILogger<DiscountController> logger)
    {
      _logger = logger;
    }

    //[HttpGet]
  }
}
