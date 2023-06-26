using GeekShopping.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult>ProductIndex()
        {
            var product = await  _productService.FindAllProducts();
            return View(product);
        }
    }
}
