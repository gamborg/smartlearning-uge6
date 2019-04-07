using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using my_pizza.Models;

namespace my_pizza.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<Order> Add(Order order);
        //void Remove(BasketItem item);
        Task<Order> Get(int id);
        Task<Order> Update(Order order);
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
            order.CreatedAt = DateTime.Now;
            order.Fee = 35;
            order.Currency = "DKK";
            var sum = order.Products.Sum(x => x.Qty * x.Price);
            order.Total = order.Fee + sum;
            order.Status = Status.AWAITING_PAYMENT;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Get(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}