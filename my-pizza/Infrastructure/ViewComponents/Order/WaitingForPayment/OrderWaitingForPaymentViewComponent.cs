using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_pizza.Infrastructure.Services;
using my_pizza.Models;

namespace my_pizza.ViewComponents.Order.WaitingForPayment
{
    [ViewComponent(Name = "OrderWaitingForPayment")]
    public class OrderWaitingForPaymentViewComponent : ViewComponent
    {
        private readonly IOrderService _service;
        public OrderWaitingForPaymentViewComponent(IOrderService service) 
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var model = await _service.Get(id);

            return View(model);
        }
    }
}