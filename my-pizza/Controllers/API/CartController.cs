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

namespace my_pizza.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CatalogContext _context;

        public CartController(CatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BasketItem>>> GetAllAsync()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            return await Task.FromResult(cart);
        }

        [HttpPost]
        [Route("add/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BasketItem>>> CreateAsync(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest("Invalid id");
            }
            
            List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");

            if (cart == null) 
            {
                cart = new List<BasketItem>();
            }

            product.Qty = 1;

            cart.Add(new BasketItem { Product = product });
            HttpContext.Session.SetObjectAsJson("cart", cart);
            
            return await Task.FromResult(CreatedAtAction(nameof(CreateAsync), new { id = id }, cart));
        }

        [HttpPost]
        [Route("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BasketItem>>> RemoveAsync(int id)
        {            
            List<BasketItem> cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart");
            if (cart == null) 
            {
                return BadRequest("Basket empty");
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest("Invalid id");
            }

            var item = cart.FirstOrDefault(x => x.Product.Id == id);
            if (item != null) {
                cart.Remove(item);
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);
            
            return await Task.FromResult(cart);
        }

    }
}   