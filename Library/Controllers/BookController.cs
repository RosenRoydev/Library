using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookFormViewModel();
            model.Categories = GetCategoryTypes();

           return View (model);
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
    }
}
