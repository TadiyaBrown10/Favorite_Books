using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Favorite_Books.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Favorite_Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository repo;

        public BooksController(IBooksRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var books = repo.GetALLBooks();
            return View(books);
        }

        public IActionResult ViewBooks(int ID)
        {
            var books = repo.GetBooks(ID);
            return View(books);
        }

        public IActionResult UpdateBooks(int ID)
        {
            Books book = repo.GetBooks(ID);

            if (book == null)
            {
                return View("ProductNotFound");
            }

            return View(book);
        }
        
        

        public IActionResult UpdateBooksToDatabase(Books books)
        {
            repo.UpdateBooks(books);

            return RedirectToAction("ViewBooks", new { id = books.ID });
        }
    }
}

