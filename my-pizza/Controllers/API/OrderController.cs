using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_pizza.Infrastructure.Factories;
using my_pizza.Infrastructure.Helpers;
using my_pizza.Models;

namespace my_pizza.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly CatalogContext _context;

        public OrderController(CatalogContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("fullfill/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BasketItem>>> CreateOrderAsync([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid id");
            }

            List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            if (cart == null) 
            {
                return BadRequest("No items in cart");
            }

            return await Task.FromResult("");
            //return await Task.FromResult(CreatedAtAction(nameof(CreateAsync), new { id = id }, cart));
        }
    }
}