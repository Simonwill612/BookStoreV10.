using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreV10.Data;
using BookStoreV10.Models;

namespace BookStoreV10.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookStoreV10Context _context;

        public BooksController(BookStoreV10Context context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Book.Include(b => b.StoreOwner).ToListAsync();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.StoreOwner)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["StoreOwnerId"] = new SelectList(_context.Set<StoreOwner>(), "StoreOwnerId", "StoreOwnerId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,AuthorName,PublisherName,Price,ImageUrl,StoreOwnerId,CoverImageFile")] Book book)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload logic if a cover image file is selected
                if (book.CoverImageFile != null && book.CoverImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await book.CoverImageFile.CopyToAsync(memoryStream);
                        book.CoverImageData = memoryStream.ToArray();
                    }
                }

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["StoreOwnerId"] = new SelectList(_context.Set<StoreOwner>(), "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            ViewData["StoreOwnerId"] = new SelectList(_context.Set<StoreOwner>(), "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,AuthorName,PublisherName,Price,ImageUrl,StoreOwnerId,CoverImageFile")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if a new cover image file is uploaded
                    if (book.CoverImageFile != null && book.CoverImageFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await book.CoverImageFile.CopyToAsync(memoryStream);
                            book.CoverImageData = memoryStream.ToArray();
                        }
                    }

                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["StoreOwnerId"] = new SelectList(_context.Set<StoreOwner>(), "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
            return View(book);
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.StoreOwner)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book != null)
            {
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }
    }
}
