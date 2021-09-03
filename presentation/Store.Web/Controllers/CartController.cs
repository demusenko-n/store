using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public CartController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Add(int id)
        {
            var book = _bookRepository.GetById(id);

            //if (book == null)
            //{
            //    return View("Error", new ErrorViewModel { RequestId = $"Cannot find book with id {id}" });
            //}

            Cart cart = HttpContext.Session.GetCart() ?? new Cart();
            if (cart.Items.ContainsKey(id))
            {
                cart.Items[id]++;
            }
            else
            {
                cart.Items[id] = 1;
            }
            cart.Price += book.Price;
            HttpContext.Session.SetCart(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}