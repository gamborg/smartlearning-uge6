using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_pizza.Models;

namespace my_pizza.Infrastructure.ViewComponts.Catalog
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly CatalogContext _context;
        public CategoryListViewComponent(CatalogContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetCategoriessAsync();
            return View(items);
        }

        private Task<List<Category>> GetCategoriessAsync()
        {
            return _context.Categories.ToListAsync();
        }
    }
}