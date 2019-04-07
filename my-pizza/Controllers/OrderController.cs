using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_pizza.Infrastructure.Factories;
using my_pizza.Infrastructure.Helpers;
using my_pizza.Infrastructure.Services;
using my_pizza.Models;

namespace my_pizza.Areas.Orders
{
    [Route("order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Order>> ShowOrderAsync(int id)
        {
            var order = await _orderService.Get(id);
            return View("Show", order);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult<Order>> UpdateOrderAsync(int id)
        {
            var order = await _orderService.Get(id);
            if (order != null)
            {
                Status newStatus = Status.PENDING;
                switch(order.Status)
                {
                    case Status.PENDING: newStatus = Status.AWAITING_PAYMENT; break;
                    case Status.AWAITING_PAYMENT: newStatus = Status.AWAITING_FULFILLMENT; break;
                    case Status.AWAITING_FULFILLMENT: newStatus = Status.AWAITING_DELIVERY; break;
                    case Status.AWAITING_DELIVERY: newStatus = Status.AWAITING_PICKUP; break;
                }

                order.Status = newStatus;
            }
            order = await _orderService.Update(order);

            return View("Show", order);
        }
    }
}