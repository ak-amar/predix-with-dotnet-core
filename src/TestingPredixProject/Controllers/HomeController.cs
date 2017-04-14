using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingPredixProject.Models;

namespace TestingPredixProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksDbContext _context;
        public HomeController(BooksDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetBooks()
        {
            try
            {
                List<Book> books = _context.Books.ToList();
                return Json(new { result = books, status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, exception = e });
            }
        }
    }
}
