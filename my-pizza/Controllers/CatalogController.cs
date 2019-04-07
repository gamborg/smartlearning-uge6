using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using my_pizza.Infrastructure.Helpers;
using my_pizza.Models;

namespace my_pizza.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogContext _context;
        public CatalogController(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            var category = await Task.FromResult(_context.Categories.FirstOrDefault(x => x.Id == id));
            ViewBag.CategoryId = id;
            return View(category);
        }

        public async Task<IActionResult> AddToCart(int productId, int qty, int categoryId = 1)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null) 
            {
                List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");

                if (cart == null) 
                {
                    cart = new List<BasketItem>();
                }

                product.Qty = qty;

                cart.Add(new BasketItem { Product = product });
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
            
            ViewBag.CategoryId = categoryId;

            var category = await Task.FromResult(_context.Categories.FirstOrDefault(x => x.Id == categoryId));
            return View("Index", category);
        }
    }
}