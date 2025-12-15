using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Dto;

namespace Ispit.Books.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;


        public AdminController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        public IActionResult Administration()
        {
            var books = bookService.GetAllBooks();
            return View(books);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            bookService.AddBook(model,User);
            return RedirectToAction("Administration");
        }


        public IActionResult Edit(int id)
        {
            var book = bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            bookService.UpdateBook(model);
            return RedirectToAction("Administration");
        }

        public IActionResult Details(int id)
        {
            var book = bookService.GetBook(id);
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            bookService.DeleteBook(id);
            return RedirectToAction("Administration");
        }
    }
}
