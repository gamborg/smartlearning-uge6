using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_pizza.Models;

namespace my_pizza.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<Order> Add(Order order);
        //void Remove(BasketItem item);
        Task<Order> Get(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly CatalogContext _context;
        public OrderService(CatalogContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Get(int id)
        {
            var order = await _context.Orders.FindAsync(new { Id = id });
            return order;
        }
    }
}