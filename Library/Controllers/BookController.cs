using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext context;

        public BookController(LibraryDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Books
                .Select(b => new BookAllViewModel
                {
                    Id = b.Id,
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookFormViewModel();
            model.Categories = GetCategoryTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            if (model.Rating < 0 || model.Rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "The rating value is out of range.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var entity = new Book()
            {

                Title = model.Title,
                Author = model.Author,
                Rating = model.Rating,
                Description = model.Description,
                ImageUrl = model.Url,
                CategoryId = model.CategoryId,

            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await context.Books.FindAsync(id);


            if (book == null)
            {
                return RedirectToAction(nameof(All), nameof(Book));
            }

            var currentUserId = GetUserId();
            if (currentUserId == null)
            {
                return RedirectToAction(nameof(Index), nameof(HomeController));
            }

            var alreadyAdded = await context.IdentityUsersBooks
                .AnyAsync(iu => iu.CollectorId == currentUserId && iu.Book.Id == book.Id);


            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = currentUserId,
                    BookId = book.Id
                };

                await context.IdentityUsersBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(All));
            }
            return RedirectToAction(nameof(All));


        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            var model = await context.IdentityUsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new BookAllViewModel
                {
                    Id = b.BookId,
                    ImageUrl = b.Book.ImageUrl,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Rating = b.Book.Rating,
                    Category = b.Book.Category.Name,
                    Description = b.Book.Description,

                })
               .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await GetBookById(id);

            if (book == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            var existingBook = await context.IdentityUsersBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == currentUserId && ub.BookId == book.Id);

            if (existingBook != null)
            {
                context.IdentityUsersBooks.Remove(existingBook);
               await context.SaveChangesAsync();
                return RedirectToAction(nameof(Mine));

            }
            return BadRequest();
        }

        private async Task<BookAllViewModel> GetBookById(int id)
        {
            var book = await context.Books
               .Where(b => b.Id == id)
               .Include(b => b.UsersBooks)
               .Select(b => new BookAllViewModel
               {
                   Id = b.Id,
                   ImageUrl = b.ImageUrl,
                   Title = b.Title,
                   Author = b.Author,
                   Rating = b.Rating,
                   Description = b.Description,
                   Category = b.Category.Name
               })
               .FirstOrDefaultAsync();
            return book;
        }
        public IEnumerable<CategoryTypesViewModel> GetCategoryTypes()
        {
            return context.Categories
                .Select(c => new CategoryTypesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();

        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? String.Empty;
        }
    }
}
