using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_pizza.Infrastructure.Factories;
using my_pizza.Infrastructure.Helpers;
using my_pizza.Infrastructure.Services;
using my_pizza.Models;

namespace my_pizza.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> CreateOrderAsync([FromBody] Customer customer)
        {
            List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            if (cart == null) 
            {
                return BadRequest("No items in cart");
            }

            var order = new Order();
            order.Customer = customer;
            order.Products = new List<Product>();
            
            foreach (var cartItem in cart) 
            {
                order.Products.Add(cartItem.Product);
            }
            
            return await _orderService.Add(order);
        }
    }
}