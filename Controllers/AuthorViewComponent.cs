using BookStoreV10.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; // Add this namespace for Task and ToListAsync

namespace BookStoreV10.Controllers
{
    [ViewComponent(Name = "Author")]
    public class AuthorViewComponent : ViewComponent
    {
        private readonly BookStoreV10Context _context;

        public AuthorViewComponent(BookStoreV10Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = await _context.Author.ToListAsync();
            return View("Author", authors);
        }
    }
}
