using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext context;

        public BookController(LibraryDbContext _context)
        {
            context = _context;
        }
        public async Task  <IActionResult> All()
        {
            var model = await context.Books
                .Select(b=> new BookAllViewModel
                {
                   ImageUrl = b.ImageUrl,
                   Title = b.Title,
                   Author = b.Author,
                   Rating = b.Rating,
                   Category = b.Category.Name
                })
                .AsNoTracking()
                .ToListAsync();
            return View(model);
        }
    }
}
