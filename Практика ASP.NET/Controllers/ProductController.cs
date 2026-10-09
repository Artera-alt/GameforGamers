using Microsoft.AspNetCore.Mvc;

namespace Практика_ASP.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetProductsAsync();
            return View(products);
        }
    }

}

