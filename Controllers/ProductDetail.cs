using Microsoft.AspNetCore.Mvc;

namespace BookStoreV10.Controllers
{
    public class ProductDetail : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
