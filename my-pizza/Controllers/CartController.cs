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

namespace my_pizza.Controllers
{
    public class CartController : Controller
    {
        private readonly CatalogContext _context;
        private readonly IOrderService _orderService;

        public CartController(CatalogContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            return View("Index", cart);
        }

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            if (cart == null) 
            {
                RedirectToAction("Index");
            }
            return View(cart);
        }

        public IActionResult RemoveItem(int id)
        {            
            List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            if (cart == null) 
            {
                return RedirectToAction("Index", "Catalog");
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var item = cart.FirstOrDefault(x => x.Product.Id == id);
            if (item != null) {
                cart.Remove(item);
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);
            
            return RedirectToAction("Index");
        }

    }
}