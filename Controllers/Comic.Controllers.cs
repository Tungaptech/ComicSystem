using Comic.Data;
using Comic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comic.Controllers
{
    public class ComicBookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action để hiển thị danh sách ComicBooks
        public IActionResult Index()
        {
            var comicBooks = _context.ComicBooks.ToList(); // Lấy danh sách ComicBooks từ database
            return View(comicBooks); // Trả về View với dữ liệu
        }

        // Action để hiển thị chi tiết một ComicBook
        public IActionResult Details(int id)
        {
            var comicBook = _context.ComicBooks.FirstOrDefault(cb => cb.ComicBookId == id);
            if (comicBook == null)
            {
                return NotFound();
            }
            return View(comicBook);
        }

        // Action để tạo ComicBook mới (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Action để tạo ComicBook mới (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ComicBook comicBook)
        {
            if (ModelState.IsValid)
            {
                _context.ComicBooks.Add(comicBook);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(comicBook);
        }
    }
}