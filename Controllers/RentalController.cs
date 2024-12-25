using Comic.Data;
using Microsoft.AspNetCore.Mvc;

namespace Comic.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action để hiển thị báo cáo
        public IActionResult Report()
        {
            var reportData = from rental in _context.Rentals
                join rentalDetail in _context.RentalDetails on rental.RentalId equals rentalDetail.RentalId
                join comicBook in _context.ComicBooks on rentalDetail.ComicBookId equals comicBook.ComicBookId
                join customer in _context.Customers on rental.CustomerId equals customer.CustomerId
                select new
                {
                    BookName = comicBook.Name,
                    RentalDate = rental.RentalDate,
                    ReturnDate = rental.ReturnDate,
                    CustomerName = customer.Fullname,
                    Quantity = rentalDetail.Quantity
                };

            return View(reportData.ToList());
        }
    }
}