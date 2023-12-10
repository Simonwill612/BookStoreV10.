using BookStoreV10.Data;
using BookStoreV10.Models;
using Microsoft.AspNetCore.Mvc;
namespace BookStoreV10.Controllers
{
    public class Adm : Controller
    {
        private readonly BookStoreV10Context _context;
        public Adm(BookStoreV10Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginAdmin()
        {
            return View();
        }
            }
    }

