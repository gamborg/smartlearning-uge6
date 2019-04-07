namespace my_pizza.Infrastructure.ViewComponts.Catalog
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using my_pizza.Models;

    [ViewComponent(Name = "Product")]
    public class ProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Product product)
        {
            return await Task.FromResult(View(product));
        }
    }
}