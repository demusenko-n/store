using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index(int id)
        {
            Book? book = _bookRepository.GetById(id);
            return book == null ? 
                View("Error", new ErrorViewModel { RequestId = $"Cannot find book with id {id}" }) 
                : View(book);
        }
    }
}