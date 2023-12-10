using Microsoft.AspNetCore.Mvc;
using BookStoreV10.Models;
using BookStoreV10.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace BookStoreV10.Controllers
{
    public class LoginController : Controller
    {
        private readonly BookStoreV10Context _context;

        public LoginController(BookStoreV10Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Book.Include(b => b.StoreOwner).ToListAsync();
            return View(books);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Customer _customerFromPage)
        {
            var _customer = _context.Customers.Where(m => m.Email == _customerFromPage.Email && m.Password == _customerFromPage.Password).FirstOrDefault();
            if (_customer == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,_customer .Email),
            new Claim("Password", _customer.Password),
            new Claim(ClaimTypes.Gender, _customer.Gender),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    
                };

                 HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public IActionResult LoginAdmin(Admin _adminFromPage)
        {
            var _admin = _context.Admin.Where(m => m.Name == _adminFromPage.Name && m.Password == _adminFromPage.Password).FirstOrDefault();
            if (_admin == null)
            {
                ViewBag.LoginAdminStatus = 0;
            }
            else
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,_admin .Name),
            new Claim("Password", _admin.Password),
            
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                };

                HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   authProperties);
                return RedirectToAction("LoginAdmin", "Adm");
            }
            return View();
        }

    }
}
